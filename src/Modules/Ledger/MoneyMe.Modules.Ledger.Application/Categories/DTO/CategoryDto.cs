namespace MoneyMe.Modules.Ledger.Application.Categories.DTO;

public class CategoryDto
{
	public Guid Id { get; set; }

	public Guid InvestmentId { get; set; }

	public string Name { get; set; }

	public string Type { get; set; }
}