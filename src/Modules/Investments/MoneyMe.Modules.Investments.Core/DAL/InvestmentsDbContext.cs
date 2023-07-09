using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.DAL;

internal class InvestmentsDbContext : DbContext
{
	public InvestmentsDbContext(DbContextOptions<InvestmentsDbContext> options) : base(options) { }

	public DbSet<Investment> Investments { get; set; }

	public DbSet<InvestmentComponent> InvestmentComponents { get; set; }
	
	public DbSet<InvestmentContributor> InvestmentContributors { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("investments");
		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
}