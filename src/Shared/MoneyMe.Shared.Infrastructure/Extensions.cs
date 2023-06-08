using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Infrastructure.Api;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.OpenApi.Models;
using MoneyMe.Shared.Abstractions.Modules;
using MoneyMe.Shared.Abstractions.Time;
using MoneyMe.Shared.Infrastructure.Auth;
using MoneyMe.Shared.Infrastructure.Commands;
using MoneyMe.Shared.Infrastructure.Contexts;
using MoneyMe.Shared.Infrastructure.Events;
using MoneyMe.Shared.Infrastructure.Exceptions;
using MoneyMe.Shared.Infrastructure.Kernel;
using MoneyMe.Shared.Infrastructure.Messaging;
using MoneyMe.Shared.Infrastructure.Modules;
using MoneyMe.Shared.Infrastructure.Queries;
using MoneyMe.Shared.Infrastructure.Services;
using MoneyMe.Shared.Infrastructure.Time;

[assembly:InternalsVisibleTo("MoneyMe.Bootstrapper")]

namespace MoneyMe.Shared.Infrastructure;

internal static class Extensions
{
	private const string CorsPolicy = "cors";

	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration,
		IList<IModule> modules,
		IList<Assembly> assemblies)
	{
		var disabledModules = new List<string>();

		foreach (var (key, value) in configuration.AsEnumerable())
		{
			if (!key.Contains(":module:enabled"))
			{
				continue;
			}

			if (!bool.Parse(value))
			{
				disabledModules.Add(key.Split(":")[0]);
			}
		}

		services.AddCors(
			cors =>
			{
				cors.AddPolicy(
					CorsPolicy,
					p => p
					   .WithOrigins("*")
					   .WithMethods("POST", "PUT", "DELETE")
					   .WithHeaders("Content-Type", "Authorization"));
			});

		services.AddSwaggerGen(
			swagger =>
			{
				swagger.CustomSchemaIds(p => p.FullName);
				swagger.SwaggerDoc(
					"v1",
					new OpenApiInfo
					{
						Title = "MoneyMe API",
						Version = "v1"
					});
			});

		services.AddSingleton<IContextFactory, ContextFactory>();
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddTransient(sp => sp.GetRequiredService<IContextFactory>().Create());
		services.AddModuleInfo(modules);
		services.AddModuleRequests(assemblies);
		services.AddAuth(modules);
		services.AddErrorHandling();
		services.AddCommands(assemblies);
		services.AddQueries(assemblies);
		services.AddDomainEvents(assemblies);
		services.AddEvents(assemblies);
		services.AddMessaging();
		services.AddSingleton<IClock, UtcClock>();
		services.AddHostedService<AppInitializer>();
		services
		   .AddControllers()
		   .ConfigureApplicationPartManager(
				manager =>
				{
					var removedParts = new List<ApplicationPart>();

					foreach (var disabledModule in disabledModules)
					{
						var parts = manager.ApplicationParts
						   .Where(
								x => x.Name.Contains(
									disabledModule,
									StringComparison.InvariantCultureIgnoreCase));

						removedParts.AddRange(parts);
					}

					foreach (var part in removedParts)
					{
						manager.ApplicationParts.Remove(part);
					}

					manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
				});

		return services;
	}

	public static WebApplication UseInfrastructure(this WebApplication app)
	{
		app.UseCors(CorsPolicy);
		app.UseErrorHandling();
		app.UseSwagger();
		app.UseReDoc(
			reDoc =>
			{
				reDoc.RoutePrefix = "docs";
				reDoc.SpecUrl = "/swagger/v1/swagger.json";
				reDoc.DocumentTitle = "MoneyMe API";
			});

		app.UseAuthentication();
		app.UseRouting();
		app.UseAuthorization();

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