using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.DAL;

internal class LedgerDbContext : DbContext
{
	public LedgerDbContext(DbContextOptions<LedgerDbContext> options) : base(options) { }

	public DbSet<Category> Categories { get; set; }

	public DbSet<Expense> Expenses { get; set; }

	public DbSet<Income> Incomes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("ledger");
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}