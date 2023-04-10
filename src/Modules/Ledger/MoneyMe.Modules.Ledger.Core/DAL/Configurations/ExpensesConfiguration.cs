using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.DAL.Configurations;

internal class ExpensesConfiguration : IEntityTypeConfiguration<Expense>
{
	public void Configure(EntityTypeBuilder<Expense> builder) { }
}