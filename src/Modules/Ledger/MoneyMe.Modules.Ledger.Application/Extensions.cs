using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Application.Expenses.Services;

namespace MoneyMe.Modules.Ledger.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEventMapper, EventMapper>();
    }
}