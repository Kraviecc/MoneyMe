using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Messaging;
using MoneyMe.Shared.Infrastructure.Messaging.Brokers;
using MoneyMe.Shared.Infrastructure.Messaging.Dispatchers;

namespace MoneyMe.Shared.Infrastructure.Messaging;

internal static class Extensions
{
	private const string ConfigurationSectionName = "messaging";

	internal static IServiceCollection AddMessaging(this IServiceCollection services)
	{
		services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();
		services.AddSingleton<IMessageChannel, MessageChannel>();
		services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();

		var messagingOptions = services.GetOptions<MessagingOptions>(ConfigurationSectionName);
		services.AddSingleton(messagingOptions);

		if (messagingOptions.UseBackgroundDispatcher)
		{
			services.AddHostedService<BackgroundDispatcher>();
		}

		return services;
	}
}