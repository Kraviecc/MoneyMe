﻿using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands;

public record DeleteExpense(Guid Id) : ICommand;