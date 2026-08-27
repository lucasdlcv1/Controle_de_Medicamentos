
// Objeto de config do servidor

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Habilita o armazanamento em JSON
InjecaoDependencia.AddInfraestruturaemJson(builder.Services);

builder.Services.AddInfraestruturaemJson();

//Habilita o MVC
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Middleware
app.UseRouting();
app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();


