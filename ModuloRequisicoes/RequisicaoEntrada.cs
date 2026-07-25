using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

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
