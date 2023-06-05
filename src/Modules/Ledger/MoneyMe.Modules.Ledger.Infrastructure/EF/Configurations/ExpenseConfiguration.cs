using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Configurations;

internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
	public void Configure(EntityTypeBuilder<Expense> builder)
	{
		builder.HasKey(p => p.Id);
		builder
		   .Property(p => p.Id)
		   .HasConversion(
				p => p.Value,
				p => new AggregateId(p));

		builder.Property(p => p.Version).IsConcurrencyToken();

		builder
		   .Property(p => p.InvestmentComponentId)
		   .HasConversion(
				p => p.Value,
				p => new InvestmentComponentId(p));
	}
}