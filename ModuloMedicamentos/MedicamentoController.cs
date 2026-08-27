using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFornecedores;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using Microsoft.AspNetCore.Mvc;

public sealed class MedicamentoController : Controller
{
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    private readonly RepositorioFornecedorEmArquivo repositorioFornecedor;

    public MedicamentoController(
        RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFornecedorEmArquivo repositorioFornecedor
    )
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFornecedor = repositorioFornecedor;
    }

    [HttpGet]

    public ActionResult Listar()
    {

        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        List<ListarMedicamentoViewModel> viewModels = [];

        foreach (Medicamento medicamento in medicamentos)
        {
            ListarMedicamentoViewModel viewModel = new ListarMedicamentoViewModel(
                medicamento.Id,
                medicamento.Nome,
                medicamento.Descricao,
                medicamento.Fornecedor.Nome,
                medicamento.QuantidadeEmEstoque
            );

            viewModels.Add(viewModel);
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarMedicamentoViewModel viewModel = new CadastrarMedicamentoViewModel(
            Nome: "",
            Descricao: "",
            FornecedorId: 0
        ) with
        { Fornecedores = ObterFornecedores() };

        return View(viewModel);
    }



    [HttpPost]
    public ActionResult Cadastrar(CadastrarMedicamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel = viewModel with { Fornecedores = ObterFornecedores() };
            return View(viewModel);
        }

        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(viewModel.FornecedorId);

        if (fornecedor == null)
            return NotFound();

        Medicamento medicamento = new Medicamento(viewModel.Nome, viewModel.Descricao, fornecedor);

        repositorioMedicamento.Cadastrar(medicamento);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]

    public ActionResult Editar(int Id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(Id);

        if (medicamento == null)
            return NotFound();

        EditarMedicamentoViewModel viewModel = new EditarMedicamentoViewModel(
            medicamento.Id,
            medicamento.Nome,
            medicamento.Descricao,
            medicamento.Fornecedor.Id
        ) with
        { Fornecedores = ObterFornecedores() };

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(EditarMedicamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel = viewModel with { Fornecedores = ObterFornecedores() };
            return View(viewModel);
        }

        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(viewModel.FornecedorId);

        if (fornecedor == null)
            return NotFound();

        Medicamento medicamentoAtualizado = new Medicamento(viewModel.Nome, viewModel.Descricao, fornecedor);

        bool conseguiuEditar = repositorioMedicamento.Editar(viewModel.Id, medicamentoAtualizado);

        if (!conseguiuEditar)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Listar));

    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return NotFound();

        return View(medicamento);
    }

    [HttpPost]
    [ActionName("Excluir")]
    public ActionResult ConfirmarExclusao(int id)
    {
        bool conseguiuExcluir = repositorioMedicamento.Excluir(id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    private List<FornecedorMedicamentoViewModel> ObterFornecedores()
    {
        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarTodos();

        List<FornecedorMedicamentoViewModel> fornecedoresViewModel = [];

        foreach (Fornecedor fornecedor in fornecedores)
        {
            FornecedorMedicamentoViewModel fornecedorViewModel = new FornecedorMedicamentoViewModel(
                fornecedor.Id,
                fornecedor.Nome
            );

            fornecedoresViewModel.Add(fornecedorViewModel);
        }

        return fornecedoresViewModel;
    }
}
