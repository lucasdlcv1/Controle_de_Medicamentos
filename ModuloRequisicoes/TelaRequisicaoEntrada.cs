using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class TelaRequisicaoEntrada : TelaRequisicaoBase<RequisicaoEntrada>, ITelaOpcoes, ITelaCrud
{
    public TelaRequisicaoEntrada(
        RepositorioRequisicaoEntradaEmArquivo repositorioRequisicao,
        RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFuncionarioEmArquivo repositorioFuncionario
    ) : base("Requisição de Entrada", repositorioRequisicao, repositorioMedicamento, repositorioFuncionario)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Entrada");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -20}",
            "Id", "Medicamento", "Qtd", "Data", "Funcionario"
        );

        List<RequisicaoEntrada> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoEntrada r in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -20}",
                r.Id, r.Medicamento.Nome, r.Quantidade, r.Data.ToShortDateString(), r.Funcionario.Nome
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoEntrada ObterDadosCadastrais()
    {
        Medicamento medicamento = SelecionarMedicamento();
        int quantidade = SelecionarQuantidade();
        Funcionario funcionario = SelecionarFuncionario();

        return new RequisicaoEntrada(medicamento, quantidade, funcionario);
    }

    protected override bool ExistemDependenciasAtivasDoRegistro(int idRegistro)
    {
        return false;
    }
}
