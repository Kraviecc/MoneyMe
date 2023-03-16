using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Exceptions;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.Services;

internal class InvestmentService : IInvestmentService
{
	private readonly IInvestmentRepository _investmentRepository;

	public InvestmentService(IInvestmentRepository investmentRepository)
	{
		_investmentRepository = investmentRepository;
	}

	public async Task AddAsync(InvestmentDetailsDto dto)
	{
		dto.Id = Guid.NewGuid();
		await _investmentRepository.AddAsync(
			new Investment
			{
				Id = dto.Id,
				Name = dto.Name,
				Description = dto.Description
			});
	}

	public Task<InvestmentDetailsDto> GetAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<IReadOnlyList<InvestmentDto>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(InvestmentDetailsDto dto)
	{
		var investment = await _investmentRepository.GetAsync(dto.Id);

		if (investment is null)
		{
			throw new InvestmentNotFoundException(dto.Id);
		}

		investment.Name = dto.Name;
		investment.Description = dto.Description;
		await _investmentRepository.UpdateAsync(investment);
	}

	public async Task DeleteAsync(Guid id)
	{
		var investment = await _investmentRepository.GetAsync(id);

		if (investment is null)
		{
			return;
		}

		await _investmentRepository.DeleteAsync(id);
	}
}