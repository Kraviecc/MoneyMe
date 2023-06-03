using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Investments.Core.Events.External.Handlers;

internal class ExpenseCreatedHandler : IEventHandler<ExpenseCreated>
{
	public async Task HandleAsync(ExpenseCreated @event)
	{
		await Task.CompletedTask;
	}
}