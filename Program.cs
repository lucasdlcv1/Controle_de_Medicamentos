
// Objeto de config do servidor
using ControleDeMedicamentos.WebApp.Compartilhado.Arquivos;
using ControleDeMedicamentos.WebApp.ModuloFornecedores;
using ControleDeMedicamentos.WebApp.ModuloFuncionarios;
using ControleDeMedicamentos.WebApp.ModuloMedicamentos;
using ControleDeMedicamentos.WebApp.ModuloPacientes;
using ControleDeMedicamentos.WebApp.ModuloRequisicoes;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adciona e injeta as dependencias do repositorio por requisição
builder.Services.AddScoped<ContextoJson>(ContextoJson.InjetarContexto);
builder.Services.AddScoped<RepositorioMedicamentoEmArquivo>();
builder.Services.AddScoped<RepositorioFornecedorEmArquivo>();
builder.Services.AddScoped<RepositorioFuncionarioEmArquivo>();
builder.Services.AddScoped<RepositorioPacienteEmArquivo>();
builder.Services.AddScoped<RepositorioRequisicaoEntradaEmArquivo>();
builder.Services.AddScoped<RepositorioRequisicaoSaidaEmArquivo>();

//Habilita o MVC
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Middleware
app.UseRouting();
app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();


