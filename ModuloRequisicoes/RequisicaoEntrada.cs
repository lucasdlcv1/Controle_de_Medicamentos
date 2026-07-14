using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicoes;

public class RequisicaoEntrada : RequisicaoBase
{
    public RequisicaoEntrada() { }

    public RequisicaoEntrada(Medicamento medicamento, int quantidade, Funcionario funcionario) : this()
    {
        Medicamento = medicamento;
        Quantidade = quantidade;
        Funcionario = funcionario;

        medicamento.RegistrarRequisicao(this);
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        ValidarCamposComuns(erros);

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoEntrada requisicaoAtualizada = (RequisicaoEntrada)entidadeAtualizada;

        AtualizarCamposComuns(requisicaoAtualizada);
    }
}
