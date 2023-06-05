using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF;

internal sealed class ExpensesDbContext : DbContext
{
	public DbSet<Expense?> Expenses { get; set; }

	public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("ledger");
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}