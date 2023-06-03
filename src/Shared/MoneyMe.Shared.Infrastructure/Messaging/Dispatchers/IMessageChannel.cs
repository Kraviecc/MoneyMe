using MoneyMe.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace MoneyMe.Shared.Infrastructure.Messaging.Dispatchers;

public interface IMessageChannel
{
	ChannelReader<IMessage> Reader { get; }

	ChannelWriter<IMessage> Writer { get; }
}