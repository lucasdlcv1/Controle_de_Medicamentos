using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloRequisicoes;

public record MedicamentoRequisicaoEntradaViewModel(
    int Id,
    string Nome
);

public record FuncionarioRequisicaoEntradaViewModel(
    int Id,
    string Nome
);

public record ListarRequisicaoEntradaViewModel(
    int Id,
    string NomeMedicamento,
    string NomeFuncionario,
    int Quantidade,
    DateTime Data
);

public record CadastrarRequisicaoEntradaViewModel(
    [Range(1, int.MaxValue, ErrorMessage = "O medicamento deve ser selecionado")]
    int MedicamentoId,
    [Range(1, int.MaxValue, ErrorMessage = "O funcionário deve ser selecionado")]
    int FuncionarioId,
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    int Quantidade
)
{
    public List<MedicamentoRequisicaoEntradaViewModel> Medicamentos { get; init; } = [];
    public List<FuncionarioRequisicaoEntradaViewModel> Funcionarios { get; init; } = [];
}
