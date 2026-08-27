using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloMedicamentos;

public record FornecedorMedicamentoViewModel(
    int Id,
    string Nome
);

public record ListarMedicamentoViewModel(
    int Id,
    string Nome,
    string Descricao,
    string NomeFornecedor,
    int QuantidadeEmEstoque
);


public record CadastrarMedicamentoViewModel(
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 255 caracteres")]
    string Descricao,
    [Range(1, int.MaxValue, ErrorMessage = "O fornecedor deve ser selecionado")]
    int FornecedorId
)
{
    public List<FornecedorMedicamentoViewModel> Fornecedores { get; init; } = [];
}

public record EditarMedicamentoViewModel(
    int Id,
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 255 caracteres")]
    string Descricao,
    [Range(1, int.MaxValue, ErrorMessage = "O fornecedor deve ser selecionado")]
    int FornecedorId
)
{
    public List<FornecedorMedicamentoViewModel> Fornecedores { get; init; } = [];
}
