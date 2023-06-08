using MoneyMe.Modules.Ledger.Application.LedgerEntries.Events.External;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Commands.Handlers;

public sealed class DeleteIncomeHandler : ICommandHandler<DeleteIncome>
{
	private readonly IIncomeRepository _incomeRepository;
	private readonly IMessageBroker _messageBroker;

	public DeleteIncomeHandler(
		IIncomeRepository incomeRepository,
		IMessageBroker messageBroker)
	{
		_incomeRepository = incomeRepository;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(DeleteIncome command)
	{
		await _incomeRepository.DeleteAsync(command.Id);
		await _messageBroker.PublishAsync(new LedgerEntryDeleted(command.Id));
	}
}