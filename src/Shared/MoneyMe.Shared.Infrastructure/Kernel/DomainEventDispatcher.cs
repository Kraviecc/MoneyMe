using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Shared.Infrastructure.Kernel;

internal sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(params IDomainEvent[]? events)
    {
        if (events is null || !events.Any())
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        foreach (var @event in events)
        {
            var handlerType = typeof(IDomainEventHandler<>)
                .MakeGenericType(@event.GetType());
            var handlers = scope.ServiceProvider.GetServices(handlerType);

            var tasks = handlers
                .Select(p => (Task)handlerType
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                    ?.Invoke(p, new[] { @event }));

            await Task.WhenAll(tasks);
        }
    }
}