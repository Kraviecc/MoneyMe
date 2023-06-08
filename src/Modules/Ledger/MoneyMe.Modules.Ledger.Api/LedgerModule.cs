using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Application;
using MoneyMe.Modules.Ledger.Domain;
using MoneyMe.Modules.Ledger.Infrastructure;
using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Modules.Ledger.Api;

internal class LedgerModule : IModule
{
	public const string BasePath = "ledger-module";

	public string Name => "Ledger";

	public string Path => BasePath;

	public IEnumerable<string>? Policies { get; } = new[]
	{
		"categories",
		"expenses",
		"incomes"
	};

	public void Register(IServiceCollection services)
	{
		services
		   .AddDomain()
		   .AddApplication()
		   .AddInfrastructure();
	}

	public void Use(IApplicationBuilder app) { }
}