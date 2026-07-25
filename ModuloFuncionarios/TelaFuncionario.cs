using ControleDeMedicamentos.WebApp.Compartilhado;

namespace ControleDeMedicamentos.WebApp.ModuloFuncionarios;

public class TelaFuncionario : TelaBase<Funcionario>, ITelaOpcoes, ITelaCrud
{
    public TelaFuncionario(RepositorioFuncionarioEmArquivo repositorio) : base("Funcionário", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Funcionários");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
            "Id", "Nome", "Telefone", "CPF"
        );

        List<Funcionario> registros = repositorio.SelecionarTodos();

        foreach (Funcionario f in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
                f.Id, f.Nome, f.Telefone, f.Cpf
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Funcionario ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do funcionário: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone do funcionário: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o CPF do funcionário: ");
        string cpf = Console.ReadLine() ?? string.Empty;

        return new Funcionario(nome, telefone, cpf);
    }
}

