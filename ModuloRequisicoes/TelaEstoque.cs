using System;
using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloPacientes;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

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
