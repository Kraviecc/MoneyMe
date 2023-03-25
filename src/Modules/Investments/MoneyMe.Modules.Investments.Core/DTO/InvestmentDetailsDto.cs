namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentDetailsDto : InvestmentDto
{
	public List<InvestmentComponentDto> Components { get; set; } = new();
}