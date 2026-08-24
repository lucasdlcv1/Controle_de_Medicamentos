using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace ControleDeMedicamentos.WebApp.ModuloFuncionarios
{
    public sealed class FuncionarioController : Controller
    {
        private readonly RepositorioFuncionarioEmArquivo repositorioFuncionario;

        public FuncionarioController(RepositorioFuncionarioEmArquivo repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ActionResult Listar()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            List<ListarFuncionarioViewModel> viewModels = new List<ListarFuncionarioViewModel>();

            foreach (Funcionario f in funcionarios)
            {
                ListarFuncionarioViewModel vm = new ListarFuncionarioViewModel(
                    f.Id,
                    f.Nome,
                    f.Telefone
                );

                viewModels.Add(vm);
            }

            return View(viewModels);
        }

        [HttpGet]

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVm)
        {
            Funcionario funcionario = new Funcionario(
            cadastrarVm.Nome,
            cadastrarVm.Telefone,
            cadastrarVm.Cpf
            );

            repositorioFuncionario.Cadastrar(funcionario);

            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]

        public ActionResult Editar(int id)
        {
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);

            if (funcionario == null)
                return NotFound();

            EditarFuncionarioViewModel vm = new EditarFuncionarioViewModel(
                funcionario.Id,
                funcionario.Nome,
                funcionario.Telefone,
                funcionario.Cpf
            );

            return View(vm);
        }

        [HttpPost]
        public ActionResult Editar(EditarFuncionarioViewModel editarVm)
        {
            Funcionario funcionarioAtualizado = new Funcionario(
                editarVm.Nome,
                editarVm.Telefone,
                editarVm.Cpf
            );

            bool sucesso = repositorioFuncionario.Editar(editarVm.Id, funcionarioAtualizado);

            if (!sucesso)
                return NotFound();

            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]

        public ActionResult Excluir(int id)
        {
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);

            if (funcionario == null)
                return NotFound();

            ExcluirFuncionarioViewModel vm = new ExcluirFuncionarioViewModel(
                  funcionario.Id,
                  funcionario.Nome
              );

            return View(vm);
        }

        [HttpPost]
        public ActionResult Excluir(ExcluirFuncionarioViewModel excluirVm)
        {
            bool sucesso = repositorioFuncionario.Excluir(excluirVm.Id);

            if (!sucesso)
                return NotFound();

            return RedirectToAction(nameof(Listar));
        }
    }
}
