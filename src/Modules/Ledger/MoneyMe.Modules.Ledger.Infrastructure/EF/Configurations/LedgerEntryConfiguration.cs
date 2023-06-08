using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Types;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Configurations;

internal class LedgerEntryConfiguration : IEntityTypeConfiguration<LedgerEntry>
{
	public void Configure(EntityTypeBuilder<LedgerEntry> builder)
	{
		builder.HasKey(p => p.Id);

		builder
		   .Property(p => p.Id)
		   .HasConversion(
				p => p.Value,
				p => new AggregateId(p));

		builder.Property(p => p.Version).IsConcurrencyToken();

		builder
		   .HasDiscriminator<string>("Type")
		   .HasValue<Expense>(LedgerEntryType.Expense)
		   .HasValue<Income>(LedgerEntryType.Income);

		builder
		   .Property(p => p.InvestmentComponentId)
		   .HasConversion(
				p => p.Value,
				p => new InvestmentComponentId(p));

		builder
		   .Property(p => p.CategoryId)
		   .HasConversion(
				p => p.Value,
				p => new CategoryId(p));

		builder
		   .Property(p => p.UserId)
		   .HasConversion(
				p => p.Value,
				p => new UserId(p));

		builder
		   .Property(p => p.Value)
		   .HasConversion(
				p => p.Value,
				p => new MoneyValue(p));
	}
}