using MoneyMe.Modules.Investments.Api;
using MoneyMe.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
   .AddInfrastructure()
   .AddInvestments();

var app = builder.Build();
app.UseInfrastructure();

app.Run();