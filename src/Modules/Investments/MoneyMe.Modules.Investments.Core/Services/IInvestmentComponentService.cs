using MoneyMe.Modules.Investments.Core.DTO;

namespace MoneyMe.Modules.Investments.Core.Services;

internal interface IInvestmentComponentService
{
	Task AddAsync(InvestmentComponentDto dto);

	Task<InvestmentComponentDetailsDto?> GetAsync(Guid id);

	Task<IReadOnlyList<InvestmentComponentDto>> GetAllAsync();

	Task UpdateAsync(InvestmentComponentDto dto);

	Task DeleteAsync(Guid id);
}