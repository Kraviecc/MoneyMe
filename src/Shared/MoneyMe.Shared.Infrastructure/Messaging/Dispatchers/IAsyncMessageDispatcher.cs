using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Shared.Infrastructure.Messaging.Dispatchers;

internal interface IAsyncMessageDispatcher
{
	Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage;
}