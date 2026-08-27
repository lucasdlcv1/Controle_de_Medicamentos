using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public record ListarMedicamentoPrescritoRequisicaoSaidaViewModel(
    int Id,
    string Nome,
    int Quantidade
);

public record ListarRequisicaoSaidaViewModel(
    int Id,
    string NomePaciente,
    DateTime Data,
    List<ListarMedicamentoPrescritoRequisicaoSaidaViewModel> MedicamentosPrescritos
);


public record PacienteRequisicaoSaidaViewModel(
    int Id,
    string Nome
);

public record MedicamentoPrescritoRequisicaoSaidaViewModel(
    int MedicamentoId,
    string NomeMedicamento,
    int QuantidadeEmEstoque,
    bool Selecionado,
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa")]
    int Quantidade
);

public record CadastrarRequisicaoSaidaViewModel(
    [Range(1, int.MaxValue, ErrorMessage = "O paciente deve ser selecionado")]
    int PacienteId
)
{
    public List<PacienteRequisicaoSaidaViewModel> Pacientes { get; init; } = [];
    public List<MedicamentoPrescritoRequisicaoSaidaViewModel> MedicamentosPrescritos { get; init; } = [];
}
