using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloPacientes;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.Compartilhado;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public class RequisicaoSaida : RequisicaoBase
{
    public Paciente Paciente { get; set; } = null!;
    public List<MedicamentoPrescrito> MedicamentosPrescritos { get; set; } = [];
    public RequisicaoSaida() { }
    public RequisicaoSaida(Paciente paciente, List<MedicamentoPrescrito> medicamentosPrescritos) : this()
    {
        Paciente = paciente;
        MedicamentosPrescritos = medicamentosPrescritos;

        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
            mp.Medicamento.RegistrarRequisicaoSaida(this);
    }

    public int ObterQuantidade(Medicamento medicamento)
    {
        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
        {
            if (mp.Medicamento.Id == medicamento.Id)
                return mp.Quantidade;
        }

        return 0;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        ValidarCamposComuns(erros);

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" deve ser preenchido.");

        // Verifica, para cada medicamento prescrito, se a quantidade requisitada
        // não é maior que a quantidade em estoque daquele medicamento.
        foreach (MedicamentoPrescrito mp in MedicamentosPrescritos)
        {
            if (mp.Quantidade > mp.Medicamento.QuantidadeEmEstoque)
                erros.Add($"A quantidade requisitada para o medicamento \"{mp.Medicamento.Nome}\" não pode ser maior que a quantidade em estoque.");
        }

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        RequisicaoSaida requisicaoAtualizada = (RequisicaoSaida)entidadeAtualizada;

        AtualizarCamposComuns(requisicaoAtualizada);
        Paciente = requisicaoAtualizada.Paciente;
    }
}
