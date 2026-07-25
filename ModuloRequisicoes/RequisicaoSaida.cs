using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloPacientes;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.Compartilhado;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public class RequisicaoSaida : RequisicaoBase
{
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

        ValidarCamposComuns(erros);

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        if (Quantidade > Medicamento.QuantidadeEmEstoque)
            erros.Add("A quantidade requisitada não pode ser maior que a quantidade em estoque.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        AtualizarCamposComuns(requisicaoAtualizada);
        Paciente = requisicaoAtualizada.Paciente;
    }
}
