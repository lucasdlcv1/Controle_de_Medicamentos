using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.ModuloPacientes;

public record ListarPacienteViewModel(
    int Id,
    string Nome,
    string Telefone,
    string CartaoSus
);

public record CadastrarPacienteViewModel(
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "O telefone é obrigatório")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (DDD) 90000-0000")]
    string Telefone,
    [Required(ErrorMessage = "O cartão SUS é obrigatório")]
    [RegularExpression(@"^\d{15}$", ErrorMessage = "O cartão SUS deve conter 15 dígitos")]
    string CartaoSus,
    [Required(ErrorMessage = "O CPF é obrigatório")]
    [RegularExpression(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$", ErrorMessage = "O CPF deve conter 11 dígitos")]
    string Cpf
);

public record EditarPacienteViewModel(
    int Id,
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    string Nome,
    [Required(ErrorMessage = "O telefone é obrigatório")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (DDD) 90000-0000")]
    string Telefone,
    [Required(ErrorMessage = "O cartão SUS é obrigatório")]
    [RegularExpression(@"^\d{15}$", ErrorMessage = "O cartão SUS deve conter 15 dígitos")]
    string CartaoSus,
    [Required(ErrorMessage = "O CPF é obrigatório")]
    [RegularExpression(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$", ErrorMessage = "O CPF deve conter 11 dígitos")]
    string Cpf
);

public record ExcluirPacienteViewModel(
    int Id,
    string Nome
);
