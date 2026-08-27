using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.ModuloFornecedores;

public sealed class FornecedorController : Controller
{
    private readonly RepositorioFornecedorEmArquivo repositorio;

    public FornecedorController(RepositorioFornecedorEmArquivo repositorio)
    {
        this.repositorio = repositorio;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedores = repositorio.SelecionarTodos();

        return View(fornecedores);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFornecedorViewModel cadastrarVmm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVmm);

        Fornecedor fornecedor = new Fornecedor(
            cadastrarVmm.Nome,
            cadastrarVmm.Telefone,
            cadastrarVmm.Cnpj);

        repositorio.Cadastrar(fornecedor);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Fornecedor fornecedor = repositorio.SelecionarPorId(id);

        if (fornecedor == null)
            return NotFound();

        EditarFornecedorViewModel viewModel = new(
            fornecedor.Id,
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.Cnpj);

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(EditarFornecedorViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        Fornecedor fornecedorEditado = new(viewModel.Nome, viewModel.Telefone, viewModel.Cnpj);

        bool sucesso = repositorio.Editar(viewModel.Id, fornecedorEditado);

        if (!sucesso)
            return NotFound();

        return RedirectToAction(nameof(Listar));


    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Fornecedor fornecedor = repositorio.SelecionarPorId(id);

        if (fornecedor == null)
            return NotFound();

        return View(fornecedor);
    }

    [HttpPost]
    public ActionResult ConfirmarExclusao(int id)
    {
        bool sucesso = repositorio.Excluir(id);

        if (!sucesso)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }
}



