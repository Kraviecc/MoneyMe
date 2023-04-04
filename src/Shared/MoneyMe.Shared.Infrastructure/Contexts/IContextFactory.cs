using MoneyMe.Shared.Abstractions.Contexts;

namespace MoneyMe.Shared.Infrastructure.Contexts;

internal interface IContextFactory
{
    IContext Create();
}