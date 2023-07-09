using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Investments.Core;
using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Modules.Investments.Api;

internal class InvestmentsModule : IModule
{
	public const string BasePath = "investments-module";

	public string Name => "Investments";

	public string Path => BasePath;

	public IEnumerable<string>? Policies { get; } = new[]
	{
		"investments",
		"components",
		"contributors"
	};

	public void Register(IServiceCollection services)
	{
		services.AddCore();
	}

	public void Use(IApplicationBuilder app) { }
}