using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Shared.Infrastructure.Events;

public class EventDispatcher : IEventDispatcher
{
	private readonly IServiceProvider _serviceProvider;

	public EventDispatcher(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
	{
		using var scope = _serviceProvider.CreateScope();

		var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

		var tasks = handlers.Select(p => p.HandleAsync(@event));
		await Task.WhenAll(tasks);
	}
}