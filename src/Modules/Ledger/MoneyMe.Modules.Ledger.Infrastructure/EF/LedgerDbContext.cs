using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF;

internal class LedgerDbContext : DbContext
{
	public DbSet<LedgerEntry> LedgerEntries { get; set; }

	public DbSet<Category> Categories { get; set; }

	public LedgerDbContext(DbContextOptions<LedgerDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("ledger");
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}