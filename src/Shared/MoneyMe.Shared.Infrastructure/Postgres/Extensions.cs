using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyMe.Shared.Infrastructure.Postgres;

public static class Extensions
{
	internal static IServiceCollection AddPostgres(this IServiceCollection services)
	{
		var options = GetPostgresOptions(services);
		services.AddSingleton(options);

		return services;
	}

	public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
	{
		var options = GetPostgresOptions(services);
		services.AddDbContext<T>(p => p.UseNpgsql(options.ConnectionString));

		return services;
	}

	private static PostgresOptions GetPostgresOptions(IServiceCollection services)
	{
		var options = services.GetOptions<PostgresOptions>("postgres");

		return options;
	}
}