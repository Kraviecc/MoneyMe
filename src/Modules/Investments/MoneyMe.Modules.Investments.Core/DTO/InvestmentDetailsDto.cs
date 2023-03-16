namespace MoneyMe.Modules.Investments.Core.DTO;

public class InvestmentDetailsDto : InvestmentDto
{
	public List<InvestmentComponentDto> Components { get; set; }
}