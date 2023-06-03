using MoneyMe.Shared.Abstractions.Messaging;
using MoneyMe.Shared.Abstractions.Modules;

namespace MoneyMe.Shared.Infrastructure.Messaging.Brokers;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
	private readonly IModuleClient _moduleClient;

	public InMemoryMessageBroker(IModuleClient moduleClient)
	{
		_moduleClient = moduleClient;
	}

	public async Task PublishAsync(params IMessage[]? messages)
	{
		if (messages is null)
		{
			return;
		}

		var tasks = new List<Task>();

		foreach (var message in messages)
		{
			tasks.Add(_moduleClient.PublishAsync(message));
		}

		await Task.WhenAll(tasks);
	}
}