using MoneyMe.Modules.Ledger.Application.LedgerEntries.Events.External;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Commands.Handlers;

public sealed class DeleteExpenseHandler : ICommandHandler<DeleteExpense>
{
	private readonly IExpenseRepository _expenseRepository;
	private readonly IMessageBroker _messageBroker;

	public DeleteExpenseHandler(
		IExpenseRepository expenseRepository,
		IMessageBroker messageBroker)
	{
		_expenseRepository = expenseRepository;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(DeleteExpense command)
	{
		await _expenseRepository.DeleteAsync(command.Id);
		await _messageBroker.PublishAsync(new LedgerEntryDeleted(command.Id));
	}
}