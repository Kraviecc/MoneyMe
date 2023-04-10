namespace MoneyMe.Modules.Ledger.Core.Entities;

internal abstract class LedgerEntryBase
{
	public Guid Id { get; set; }

	public Guid InvestmentComponentId { get; set; }

	public Guid UserId { get; set; }

	public string Name { get; set; }

	public decimal Value { get; set; }

	public Guid CategoryId { get; set; }

	public Category Category { get; set; }
}