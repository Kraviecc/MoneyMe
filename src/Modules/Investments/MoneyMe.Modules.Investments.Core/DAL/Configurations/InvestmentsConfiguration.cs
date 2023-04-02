using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.DAL.Configurations;

internal class InvestmentsConfiguration : IEntityTypeConfiguration<Investment>
{
	public void Configure(EntityTypeBuilder<Investment> builder) { }
}