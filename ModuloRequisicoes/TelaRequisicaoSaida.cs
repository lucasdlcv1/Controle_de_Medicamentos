using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloPacientes;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public class TelaRequisicaoSaida : TelaRequisicaoBase<RequisicaoSaida>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;

    public TelaRequisicaoSaida(
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicao,
        RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFuncionarioEmArquivo repositorioFuncionario,
        RepositorioPacienteEmArquivo repositorioPaciente
    ) : base("Requisição de Saída", repositorioRequisicao, repositorioMedicamento, repositorioFuncionario)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Requisições de Saída");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -20} | {5, -20}",
            "Id", "Medicamento", "Qtd", "Data", "Funcionario", "Paciente"
        );

        List<RequisicaoSaida> registros = repositorio.SelecionarTodos();

        foreach (RequisicaoSaida r in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -20} | {5, -20}",
                r.Id, r.Medicamento.Nome, r.Quantidade, r.Data.ToShortDateString(), r.Funcionario.Nome, r.Paciente.Nome
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override RequisicaoSaida ObterDadosCadastrais()
    {
        VisualizarPacientes();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do paciente: ");
        int idPaciente = Convert.ToInt32(Console.ReadLine());

        Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente)!;

        List<MedicamentoPrescrito> medicamentosPrescritos = [];

        while (true)
        {
            VisualizarMedicamentos();

            Console.WriteLine("---------------------------------");

            Console.Write("Digite o ID do medicamento (0 para finalizar): ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            if (idMedicamento == 0)
                break;

            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento)!;

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            medicamentosPrescritos.Add(new MedicamentoPrescrito(medicamento, quantidade));
        }

        return new RequisicaoSaida(paciente, medicamentosPrescritos);
    }

    private void VisualizarPacientes()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20}",
            "Id", "Nome", "CPF"
        );

        List<Paciente> registros = repositorioPaciente.SelecionarTodos();

        foreach (Paciente p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20}",
                p.Id, p.Nome, p.Cpf
            );
        }
    }

    protected override bool ExistemDependenciasAtivasDoRegistro(int idRegistro)
    {
        return false;
    }
}


