using System.Reflection;
using MoneyMe.Shared.Abstractions.Modules;
using MoneyMe.Shared.Infrastructure.Modules;

namespace MoneyMe.Bootstrapper;

internal static class ModuleLoader
{
    public static IEnumerable<Assembly> LoadAssemblies()
    {
        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .ToList();
        var locations = assemblies
            .Where(p => !p.IsDynamic)
            .Select(p => p.Location)
            .ToArray();
        var files = Directory
            .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(p => !locations.Contains(p, StringComparer.InvariantCultureIgnoreCase))
            .ToList();

        files.ForEach(p => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(p))));

        return assemblies;
    }

    public static IList<IModule> LoadModules(
        IConfiguration configuration,
        IEnumerable<Assembly> assemblies)
    {
        return assemblies
            .SelectMany(p => p.GetTypes())
            .Where(p => typeof(IModule).IsAssignableFrom(p)
                        && !p.IsInterface
                        && IsModuleEnabled(configuration, p.Assembly))
            .OrderBy(p => p.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
    }

    private static bool IsModuleEnabled(IConfiguration configuration, Assembly assembly)
    {
        var moduleName = assembly.GetModuleName();
        return !string.IsNullOrEmpty(moduleName)
               && configuration.GetValue<bool>($"{moduleName}:module:enabled");
    }
}