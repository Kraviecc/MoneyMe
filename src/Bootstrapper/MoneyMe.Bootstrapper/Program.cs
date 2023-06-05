using MoneyMe.Bootstrapper;
using MoneyMe.Shared.Infrastructure;
using MoneyMe.Shared.Infrastructure.Modules;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureModules();

var assemblies = ModuleLoader
    .LoadAssemblies()
    .ToList();
var modules = ModuleLoader.LoadModules(builder.Configuration, assemblies);
builder.Services.AddInfrastructure(
    builder.Configuration,
    modules,
    assemblies);

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
app.MapModuleInfo();

app.Run();