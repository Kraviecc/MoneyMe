using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Users.Core;
using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Modules.Users.Api;

internal class UsersModule : IModule
{
    public const string BasePath = "users-module";
    public string Name => "Users";
    public string Path => BasePath;
    public IEnumerable<string> Policies { get; } = new[] { "users" };

    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}