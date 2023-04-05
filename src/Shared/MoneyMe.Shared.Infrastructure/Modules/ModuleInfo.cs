using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Shared.Infrastructure.Modules;

internal record ModuleInfo(string Name, string Path, IEnumerable<string>? Policies)
{
    public static ModuleInfo FromModule(IModule module)
    {
        return new ModuleInfo(module.Name, module.Path, module.Policies);
    }
}