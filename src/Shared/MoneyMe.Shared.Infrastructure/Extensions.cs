using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Infrastructure.Api;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MoneyMe.Bootstrapper")]

namespace MoneyMe.Shared.Infrastructure;

internal static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services
		   .AddControllers()
		   .ConfigureApplicationPartManager(
				manager =>
				{
					manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
				});

		return services;
	}

	public static WebApplication UseInfrastructure(this WebApplication app)
	{
		app.MapControllers();
		app.MapGet("/", () => "Hello MoneyMe!");

		return app;
	}
}