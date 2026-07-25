
// Objeto de config do servidor
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Habilita o MVC
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Middleware
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();


