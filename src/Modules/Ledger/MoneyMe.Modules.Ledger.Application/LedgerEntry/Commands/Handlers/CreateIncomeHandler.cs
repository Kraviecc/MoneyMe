using MoneyMe.Modules.Ledger.Application.LedgerEntry.Services;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands.Handlers;

public sealed class CreateIncomeHandler : ICommandHandler<CreateIncome>
{
	private readonly IIncomeRepository _incomeRepository;
	private readonly IEventMapper _eventMapper;
	private readonly IMessageBroker _messageBroker;

	public CreateIncomeHandler(
		IIncomeRepository incomeRepository,
		IEventMapper eventMapper,
		IMessageBroker messageBroker)
	{
		_incomeRepository = incomeRepository;
		_eventMapper = eventMapper;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(CreateIncome command)
	{
		var expense = Income.Create(
			command.Id,
			command.InvestmentComponentId,
			command.CategoryId,
			command.UserId,
			command.Name,
			command.Value,
			command.Date);

		var events = _eventMapper.MapAll(expense.Events);

		await _incomeRepository.AddAsync(expense);
		await _messageBroker.PublishAsync(events.ToArray());
	}
}