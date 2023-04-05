using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Shared.Infrastructure.Modules;

public static class Extensions
{
    private const string ModulePart = "MoneyMe.Modules.";

    internal static IServiceCollection AddModuleInfo(
        this IServiceCollection services,
        IEnumerable<IModule> modules)
    {
        var moduleInfoProvider = new ModuleInfoProvider();
        var moduleInfo = modules.Select(ModuleInfo.FromModule);
        moduleInfoProvider.Modules.AddRange(moduleInfo);

        services.AddSingleton(moduleInfoProvider);

        return services;
    }

    internal static void MapModuleInfo(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("modules", context =>
        {
            var moduleInfoProvider = context.RequestServices.GetRequiredService<ModuleInfoProvider>();

            return context.Response.WriteAsJsonAsync(moduleInfoProvider.Modules);
        });
    }

    internal static WebApplicationBuilder ConfigureModules(this WebApplicationBuilder builder)
    {
        foreach (var settings in GetSettings(builder.Environment, "*"))
        {
            builder.Configuration.AddJsonFile(settings);
        }

        foreach (var settings in GetSettings(builder.Environment, $"*.{builder.Environment.EnvironmentName}"))
        {
            builder.Configuration.AddJsonFile(settings);
        }

        return builder;
    }

    internal static string GetModuleName(this Assembly assembly)
    {
        var assemblyLocation = assembly.Location;
        if (!assemblyLocation.Contains(ModulePart))
        {
            return string.Empty;
        }

        return assemblyLocation
            .Split(ModulePart)[1]
            .Split(".")[0]
            .ToLower();
    }

    private static IEnumerable<string> GetSettings(IHostEnvironment environment, string pattern) =>
        Directory.EnumerateFiles(
            environment.ContentRootPath,
            $"module.{pattern}.json",
            SearchOption.AllDirectories);
}