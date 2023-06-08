using MoneyMe.Modules.Ledger.Application.LedgerEntry.Exceptions;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Services;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands.Handlers;

public sealed class UpdateIncomeHandler : ICommandHandler<UpdateIncome>
{
	private readonly IIncomeRepository _incomeRepository;
	private readonly IEventMapper _eventMapper;
	private readonly IMessageBroker _messageBroker;

	public UpdateIncomeHandler(
		IIncomeRepository incomeRepository,
		IEventMapper eventMapper,
		IMessageBroker messageBroker)
	{
		_incomeRepository = incomeRepository;
		_eventMapper = eventMapper;
		_messageBroker = messageBroker;
	}

	public async Task HandleAsync(UpdateIncome command)
	{
		var expense = await _incomeRepository.GetAsync(command.Id);

		if (expense is null)
		{
			throw new IncomeNotFoundException(command.Id);
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

		await _incomeRepository.UpdateAsync(expense);
		await _messageBroker.PublishAsync(events.ToArray());
	}
}