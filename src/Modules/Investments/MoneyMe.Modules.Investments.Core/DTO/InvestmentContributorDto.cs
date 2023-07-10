using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentContributorDto
{
    public Guid Id { get; set; }

    public InvestmentContributorType Type { get; set; }

    public Guid InvestmentComponentId { get; set; }

    public Guid InvestmentContributorId { get; set; }
}