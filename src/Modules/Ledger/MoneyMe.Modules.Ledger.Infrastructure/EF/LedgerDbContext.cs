﻿using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF;

internal sealed class LedgerDbContext : DbContext
{
	public DbSet<LedgerEntry> LedgerEntries { get; set; }

	public LedgerDbContext(DbContextOptions<LedgerDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("ledger");
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}