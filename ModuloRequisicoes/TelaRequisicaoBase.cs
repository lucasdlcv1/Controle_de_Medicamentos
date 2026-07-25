using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public abstract class TelaRequisicaoBase<TRequisicao> : TelaBase<TRequisicao> where TRequisicao : RequisicaoBase
{
    protected readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    protected readonly RepositorioFuncionarioEmArquivo repositorioFuncionario;

    protected TelaRequisicaoBase(string nomeEntidade, RepositorioBaseEmArquivo<TRequisicao> repositorio, RepositorioMedicamentoEmArquivo repositorioMedicamento, RepositorioFuncionarioEmArquivo repositorioFuncionario)
        : base(nomeEntidade, repositorio)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
    }

    protected Medicamento SelecionarMedicamento()
    {
        VisualizarMedicamentos();

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o ID do medicamento que deseja requisitar: ");
        int idMedicamento = Convert.ToInt32(Console.ReadLine());

        return repositorioMedicamento.SelecionarPorId(idMedicamento)!;
    }

    protected int SelecionarQuantidade()
    {
        Console.Write("Digite a quantidade que deseja requisitar: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    protected Funcionario SelecionarFuncionario()
    {
        VisualizarFuncionarios();

        Console.Write("Digite o ID do funcionário que está requisitando: ");
        int idFuncionario = Convert.ToInt32(Console.ReadLine());

        return repositorioFuncionario.SelecionarPorId(idFuncionario)!;
    }

    protected void VisualizarFuncionarios()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20}",
            "Id", "Nome"
        );

        List<Funcionario> registros = repositorioFuncionario.SelecionarTodos();

        foreach (Funcionario f in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20}",
                f.Id, f.Nome
            );
        }
    }

    protected void VisualizarMedicamentos()
    {
        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();
        VisualizacaoMedicamentos.Exibir(registros);
    }
}
