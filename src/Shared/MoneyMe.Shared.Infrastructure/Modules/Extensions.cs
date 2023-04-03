using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MoneyMe.Shared.Infrastructure.Modules;

public static class Extensions
{
    private const string ModulePart = "MoneyMe.Modules.";

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