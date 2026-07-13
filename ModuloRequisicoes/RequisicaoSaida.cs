using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleDeMedicamentos.ConsoleApp.ModuloPacientes;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoSaida : EntidadeBase
{
    public Medicamento Medicamento { get; set; } = null!;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;

    public Funcionario Funcionario { get; set; } = null!;

    public Paciente Paciente { get; set; } = null!;

    public RequisicaoSaida() { }

    public RequisicaoSaida(Medicamento medicamento, int quantidade, Funcionario funcionario, Paciente paciente) : this()
    {
        Medicamento = medicamento;
        Quantidade = quantidade;
        Funcionario = funcionario;
        Paciente = paciente;

        medicamento.RegistrarRequisicao(this);
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" deve ser preenchido.");

        if (Quantidade <= 0)
            erros.Add("A \"Quantidade\" deve ser maior que zero.");

        if (Funcionario == null)
            erros.Add("O campo \"Funcionario\" deve ser preenchido.");

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        if (Quantidade > Medicamento.QuantidadeEmEstoque)
            erros.Add("A quantidade requisitada não pode ser maior que a quantidade em estoque.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        Medicamento = requisicaoAtualizada.Medicamento;
        Quantidade = requisicaoAtualizada.Quantidade;
        Funcionario = requisicaoAtualizada.Funcionario;
        Paciente = requisicaoAtualizada.Paciente;
    }
}
