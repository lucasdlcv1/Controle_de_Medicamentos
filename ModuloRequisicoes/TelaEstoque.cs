using System;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class TelaEstoque : ITelaOpcoes
{
    private readonly RepositorioMedicamentoEmArquivo repositorioMedicamento;
    private readonly TelaRequisicaoEntrada telaRequisicaoEntrada;
    private readonly TelaRequisicaoSaida telaRequisicaoSaida;

    public TelaEstoque(
        RepositorioRequisicaoEntradaEmArquivo repositorioRequisicaoEntrada,
        RepositorioRequisicaoSaidaEmArquivo repositorioRequisicaoSaida,
        RepositorioMedicamentoEmArquivo repositorioMedicamento,
        RepositorioFuncionarioEmArquivo repositorioFuncionario,
        RepositorioPacienteEmArquivo repositorioPaciente)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicaoEntrada, repositorioMedicamento, repositorioFuncionario);
        telaRequisicaoSaida = new TelaRequisicaoSaida(repositorioRequisicaoSaida, repositorioMedicamento, repositorioFuncionario, repositorioPaciente);
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Controle de Medicamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Requisições de Entrada");
        Console.WriteLine("2 - Requisições de Saída");
        Console.WriteLine("3 - Visualizar Estoque de Medicamentos");
        Console.WriteLine("S - Voltar");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuEstoque = Console.ReadLine()?.ToUpper();
        return opcaoMenuEstoque;
    }

    public ITelaOpcoes? ObterTelaSelecionada(string? opcaoMenuEstoque)
    {
        if (opcaoMenuEstoque == "1")
            return telaRequisicaoEntrada;

        if (opcaoMenuEstoque == "2")
            return telaRequisicaoSaida;

        if (opcaoMenuEstoque == "3")
        {
            VisualizarEstoque();
            return this;
        }

        return this;
    }

    public void VisualizarEstoque()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Estoque de Medicamentos");
        Console.WriteLine("---------------------------------");

        List<Medicamento> registros = repositorioMedicamento.SelecionarTodos();
        VisualizacaoMedicamentos.Exibir(registros);

        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}
