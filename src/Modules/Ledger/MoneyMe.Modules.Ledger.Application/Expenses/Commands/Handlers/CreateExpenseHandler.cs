using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Modules.Ledger.Domain.Expenses.Repositories;
using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Commands.Handlers;

public sealed class CreateExpenseHandler : ICommandHandler<CreateExpense>
{
    private readonly IExpenseRepository _expenseRepository;

    public CreateExpenseHandler(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
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
    }
}