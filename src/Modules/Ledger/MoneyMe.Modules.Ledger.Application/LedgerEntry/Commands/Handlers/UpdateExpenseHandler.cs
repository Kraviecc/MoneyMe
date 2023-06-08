using MoneyMe.Modules.Ledger.Application.LedgerEntry.Exceptions;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Services;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands.Handlers;

public sealed class UpdateExpenseHandler : ICommandHandler<UpdateExpense>
{
	private readonly IExpenseRepository _expenseRepository;
	private readonly IEventMapper _eventMapper;
	private readonly IMessageBroker _messageBroker;

	public UpdateExpenseHandler(
		IExpenseRepository expenseRepository,
		IEventMapper eventMapper,
		IMessageBroker messageBroker)
	{
		_expenseRepository = expenseRepository;
		_eventMapper = eventMapper;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(UpdateExpense command)
	{
		var expense = await _expenseRepository.GetAsync(command.Id);

		if (expense is null)
		{
			throw new ExpenseNotFoundException(command.Id);
		}

		if (command.Name.IsChanged)
		{
			expense.ChangeName(command.Name.Value);
		}

		if (command.Value.IsChanged)
		{
			expense.ChangeValue(command.Value.Value);
		}

		if (command.Date.IsChanged)
		{
			expense.ChangeDate(command.Date.Value);
		}

		if (command.InvestmentComponentId.IsChanged)
		{
			expense.ChangeInvestmentComponent(command.InvestmentComponentId.Value);
		}

		if (command.CategoryId.IsChanged)
		{
			expense.ChangeCategory(command.CategoryId.Value);
		}

		var events = _eventMapper.MapAll(expense.Events);

		await _expenseRepository.UpdateAsync(expense);
		await _messageBroker.PublishAsync(events.ToArray());
	}
}