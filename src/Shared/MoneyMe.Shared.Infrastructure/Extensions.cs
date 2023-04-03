using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Infrastructure.Api;
using System.Runtime.CompilerServices;
using MoneyMe.Shared.Abstractions;
using MoneyMe.Shared.Infrastructure.Exceptions;
using MoneyMe.Shared.Infrastructure.Services;
using MoneyMe.Shared.Infrastructure.Time;

[assembly:InternalsVisibleTo("MoneyMe.Bootstrapper")]

namespace MoneyMe.Shared.Infrastructure;

internal static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddErrorHandling();
		services.AddSingleton<IClock, UtcClock>();
		services.AddHostedService<AppInitializer>();
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
		app.UseErrorHandling();

		return app;
	}

	public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
	{
		using var serviceProvider = services.BuildServiceProvider();
		var configuration = serviceProvider.GetRequiredService<IConfiguration>();

		return GetOptions<T>(configuration, sectionName);
	}

	public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
	{
		var options = new T();
		configuration.GetSection(sectionName).Bind(options);

		return options;
	}
}