using MoneyMe.Shared.Abstractions.Messaging;
using MoneyMe.Shared.Abstractions.Modules;
using MoneyMe.Shared.Infrastructure.Messaging.Dispatchers;

namespace MoneyMe.Shared.Infrastructure.Messaging.Brokers;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
	private readonly IModuleClient _moduleClient;
	private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
	private readonly MessagingOptions _messagingOptions;

	public InMemoryMessageBroker(
		IModuleClient moduleClient,
		IAsyncMessageDispatcher asyncMessageDispatcher,
		MessagingOptions messagingOptions)
	{
		_moduleClient = moduleClient;
		_asyncMessageDispatcher = asyncMessageDispatcher;
		_messagingOptions = messagingOptions;
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
			if (_messagingOptions.UseBackgroundDispatcher)
			{
				await _asyncMessageDispatcher.PublishAsync(message);

				continue;
			}

			tasks.Add(_moduleClient.PublishAsync(message));
		}

		await Task.WhenAll(tasks);
	}
}