using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(p => p.Id);

		builder
		   .Property(p => p.Id)
		   .HasConversion(
				p => p.Value,
				p => new AggregateId(p));

		builder.Property(p => p.Version).IsConcurrencyToken();

		builder
		   .Property(p => p.InvestmentId)
		   .HasConversion(
				p => p.Value,
				p => new InvestmentId(p));

		builder
		   .Property(p => p.Type)
		   .HasConversion(
				p => p.Value,
				p => new CategoryType(p));
	}
}