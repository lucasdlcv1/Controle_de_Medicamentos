using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloFornecedores;

public record ListarFornecedorViewModel(int Id, string Nome, string Telefone, string Cnpj);

public record CadastrarFornecedorViewModel(
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "O telefone é obrigatório")] string Telefone,
    [Required(ErrorMessage = "O CNPJ é obrigatório")] string Cnpj
);

public record EditarFornecedorViewModel(
    int Id,
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "O telefone é obrigatório")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (DDD) 90000-0000")]
    string Telefone,
    [Required(ErrorMessage = "O CNPJ é obrigatório")]
    [RegularExpression(@"^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}$", ErrorMessage = "O CNPJ deve conter 14 dígitos")]
    string Cnpj
);

public record ExcluirFornecedorViewModel(
    int Id,
    [Required] string Nome
);
