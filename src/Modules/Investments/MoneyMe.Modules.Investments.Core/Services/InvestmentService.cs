using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Exceptions;
using MoneyMe.Modules.Investments.Core.Policies;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.Services;

internal class InvestmentService : IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;
    private readonly IInvestmentDeletionPolicy _investmentDeletionPolicy;

    public InvestmentService(
        IInvestmentRepository investmentRepository,
        IInvestmentDeletionPolicy investmentDeletionPolicy)
    {
        _investmentRepository = investmentRepository;
        _investmentDeletionPolicy = investmentDeletionPolicy;
    }

    public async Task AddAsync(InvestmentDto dto)
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

    public async Task<InvestmentDetailsDto?> GetAsync(Guid id)
    {
        var investment = await _investmentRepository.GetAsync(id);

        if (investment is null)
        {
            return null;
        }

        var dto = Map<InvestmentDetailsDto>(investment);
        dto.Components = investment.Components
            .Select(p => new InvestmentComponentDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Investment = p.Investment,
                Type = p.Type
            })
            .ToList();

        return dto;
    }

    public async Task<IReadOnlyList<InvestmentDto>> GetAllAsync()
    {
        var investments = await _investmentRepository.GetAllAsync();

        return investments
            .Select(Map<InvestmentDto>)
            .ToList();
    }

    public async Task UpdateAsync(InvestmentDto dto)
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

        if (await _investmentDeletionPolicy.CanDeleteAsync(investment) is false)
        {
            throw new CannotDeleteInvestmentException(id, 11);
        }

        await _investmentRepository.DeleteAsync(investment);
    }

    private static T Map<T>(Investment investment) where T : InvestmentDto, new()
        => new()
        {
            Id = investment.Id,
            Name = investment.Name,
            Description = investment.Description
        };
}