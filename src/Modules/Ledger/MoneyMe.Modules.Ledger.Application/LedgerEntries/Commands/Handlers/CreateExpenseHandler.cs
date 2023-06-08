using MoneyMe.Modules.Ledger.Application.LedgerEntries.Services;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Commands.Handlers;

public sealed class CreateExpenseHandler : ICommandHandler<CreateExpense>
{
	private readonly IExpenseRepository _expenseRepository;
	private readonly IEventMapper _eventMapper;
	private readonly IMessageBroker _messageBroker;

	public CreateExpenseHandler(
		IExpenseRepository expenseRepository,
		IEventMapper eventMapper,
		IMessageBroker messageBroker)
	{
		_expenseRepository = expenseRepository;
		_eventMapper = eventMapper;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(CreateExpense command)
	{
		var expense = Expense.Create(
			command.Id,
			command.InvestmentComponentId,
			command.CategoryId,
			command.UserId,
			command.Name,
			command.Value,
			command.Date);

		var events = _eventMapper.MapAll(expense.Events);

		await _expenseRepository.AddAsync(expense);
		await _messageBroker.PublishAsync(events.ToArray());
	}
}