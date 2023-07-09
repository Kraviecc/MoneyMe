using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.DAL.Configurations;

internal class InvestmentContributorsConfiguration : IEntityTypeConfiguration<InvestmentContributor>
{
	public void Configure(EntityTypeBuilder<InvestmentContributor> builder) { }
}