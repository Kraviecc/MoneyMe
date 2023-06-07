using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Modules.Ledger.Domain.Expenses.Repositories;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Commands.Handlers;

public sealed class CreateExpenseHandler : ICommandHandler<CreateExpense>
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public CreateExpenseHandler(
        IExpenseRepository expenseRepository,
        IDomainEventDispatcher domainEventDispatcher)
    {
        _expenseRepository = expenseRepository;
        _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task HandleAsync(CreateExpense command)
    {
        var expense = Expense.Create(
            command.Id,
            command.InvestmentComponentId,
            command.CategoryId,
            command.UserId,
            command.Name,
            command.Value);

        await _expenseRepository.AddAsync(expense);
        await _domainEventDispatcher.DispatchAsync(expense.Events.ToArray());
    }
}