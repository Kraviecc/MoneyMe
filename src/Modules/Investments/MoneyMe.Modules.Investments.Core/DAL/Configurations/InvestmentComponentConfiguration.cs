using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.DAL.Configurations;

internal class InvestmentComponentConfiguration : IEntityTypeConfiguration<InvestmentComponent>
{
	public void Configure(EntityTypeBuilder<InvestmentComponent> builder) { }
}