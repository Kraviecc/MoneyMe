using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Users.Core.DAL;
using MoneyMe.Modules.Users.Core.DAL.Repositories;
using MoneyMe.Modules.Users.Core.Entities;
using MoneyMe.Modules.Users.Core.Repositories;
using MoneyMe.Modules.Users.Core.Services;
using MoneyMe.Shared.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("MoneyMe.Modules.Users.Api")]

namespace MoneyMe.Modules.Users.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
        => services
            .AddScoped<IUserRepository, UserRepository>()
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddTransient<IIdentityService, IdentityService>()
            .AddPostgres<UsersDbContext>();
}