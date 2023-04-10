using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Core;
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
		services.AddCore();
	}

	public void Use(IApplicationBuilder app) { }
}