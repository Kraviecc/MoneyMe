﻿using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Commands;

public record DeleteIncome(Guid Id) : ICommand;