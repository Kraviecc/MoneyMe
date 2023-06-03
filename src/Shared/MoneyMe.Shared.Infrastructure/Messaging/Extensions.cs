using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Messaging;
using MoneyMe.Shared.Infrastructure.Messaging.Brokers;

namespace MoneyMe.Shared.Infrastructure.Messaging;

internal static class Extensions
{
	internal static IServiceCollection AddMessaging(this IServiceCollection services)
	{
		services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();

		return services;
	}
}