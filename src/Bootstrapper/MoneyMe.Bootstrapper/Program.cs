using MoneyMe.Bootstrapper;
using MoneyMe.Shared.Infrastructure;

var assemblies = ModuleLoader.LoadAssemblies();
var modules = ModuleLoader.LoadModules(assemblies);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
foreach (var module in modules)
{
    module.Register(builder.Services);
}

var app = builder.Build();
var logger = app.Logger;
app.UseInfrastructure();
foreach (var module in modules)
{
    module.Use(app);
}

logger.LogInformation(
    "Loaded modules: {Modules}",
    string.Join(", ", modules.Select(p => p.Name)));

app.MapControllers();
app.MapGet("/", () => "Hello MoneyMe!");

app.Run();