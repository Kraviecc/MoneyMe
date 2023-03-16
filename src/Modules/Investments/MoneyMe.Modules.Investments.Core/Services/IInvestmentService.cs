using MoneyMe.Modules.Investments.Core.DTO;

namespace MoneyMe.Modules.Investments.Core.Services;

internal interface IInvestmentService
{
	Task AddAsync(InvestmentDetailsDto dto);

	Task<InvestmentDetailsDto> GetAsync(Guid id);

	Task<IReadOnlyList<InvestmentDto>> GetAllAsync();

	Task UpdateAsync(InvestmentDetailsDto dto);

	Task DeleteAsync(Guid id);
}