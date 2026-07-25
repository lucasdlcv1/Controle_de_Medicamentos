using ControleDeMedicamentos.WebApp.Compartilhado;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public abstract class RequisicaoBase : EntidadeBase
{
    public Medicamento Medicamento { get; set; } = null!;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public Funcionario Funcionario { get; set; } = null!;

    protected void ValidarCamposComuns(List<string> erros)
    {
        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" deve ser preenchido.");

        if (Quantidade <= 0)
            erros.Add("A \"Quantidade\" deve ser maior que zero.");

        if (Funcionario == null)
            erros.Add("O campo \"Funcionario\" deve ser preenchido.");
    }

    protected void AtualizarCamposComuns(RequisicaoBase requisicaoAtualizada)
    {
        Medicamento = requisicaoAtualizada.Medicamento;
        Quantidade = requisicaoAtualizada.Quantidade;
        Funcionario = requisicaoAtualizada.Funcionario;
    }
}
