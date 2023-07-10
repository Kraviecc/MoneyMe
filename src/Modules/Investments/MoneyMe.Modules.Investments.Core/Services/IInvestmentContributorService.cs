using MoneyMe.Modules.Investments.Core.DTO;

namespace MoneyMe.Modules.Investments.Core.Services;

internal interface IInvestmentContributorService
{
    Task AddAsync(InvestmentContributorDto dto);

    Task<IReadOnlyList<InvestmentContributorDetailsDto>> GetAsync(Guid investmentComponentId);

    Task DeleteAsync(Guid investmentContributorId);
}