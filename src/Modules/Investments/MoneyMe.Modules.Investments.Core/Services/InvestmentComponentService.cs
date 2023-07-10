using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Exceptions;
using MoneyMe.Modules.Investments.Core.Policies;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.Services;

internal class InvestmentComponentService : IInvestmentComponentService
{
    private readonly IInvestmentComponentRepository _investmentComponentRepository;
    private readonly IInvestmentRepository _investmentRepository;
    private readonly IInvestmentComponentDeletionPolicy _investmentComponentDeletionPolicy;

    public InvestmentComponentService(
        IInvestmentComponentRepository investmentComponentRepository,
        IInvestmentRepository investmentRepository,
        IInvestmentComponentDeletionPolicy investmentComponentDeletionPolicy)
    {
        _investmentComponentRepository = investmentComponentRepository;
        _investmentRepository = investmentRepository;
        _investmentComponentDeletionPolicy = investmentComponentDeletionPolicy;
    }

    public async Task AddAsync(InvestmentComponentDto dto)
    {
        var investment = await _investmentRepository.GetAsync(dto.InvestmentId);

        if (investment is null)
        {
            throw new InvestmentNotFoundException(dto.InvestmentId);
        }

        dto.Id = Guid.NewGuid();
        await _investmentComponentRepository.AddAsync(
            new InvestmentComponent
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                InvestmentId = dto.InvestmentId
            });
    }

    public async Task<InvestmentComponentDetailsDto?> GetAsync(Guid id)
    {
        var investmentComponent = await _investmentComponentRepository.GetAsync(id);

        if (investmentComponent is null)
        {
            return null;
        }

        return Map<InvestmentComponentDetailsDto>(investmentComponent);
    }

    public async Task<IReadOnlyList<InvestmentComponentDto>> GetAllAsync()
    {
        var investmentsComponents = await _investmentComponentRepository.GetAllAsync();

        return investmentsComponents
            .Select(Map<InvestmentComponentDto>)
            .ToList();
    }

    public async Task UpdateAsync(InvestmentComponentDto dto)
    {
        var investmentComponent = await _investmentComponentRepository.GetAsync(dto.Id);

        if (investmentComponent is null)
        {
            throw new InvestmentComponentNotFoundException(dto.Id);
        }

        investmentComponent.Name = dto.Name;
        investmentComponent.Type = dto.Type;
        investmentComponent.InvestmentId = dto.InvestmentId;
        await _investmentComponentRepository.UpdateAsync(investmentComponent);
    }

    public async Task DeleteAsync(Guid id)
    {
        var investmentComponent = await _investmentComponentRepository.GetAsync(id);

        if (investmentComponent is null)
        {
            return;
        }

        if (await _investmentComponentDeletionPolicy.CanDeleteAsync(investmentComponent) is false)
        {
            throw new CannotDeleteInvestmentComponentException(id, 11);
        }

        await _investmentComponentRepository.DeleteAsync(investmentComponent);
    }

    private static T Map<T>(InvestmentComponent investmentComponent) where T : InvestmentComponentDto, new() => new()
    {
        Id = investmentComponent.Id,
        InvestmentId = investmentComponent.InvestmentId,
        Name = investmentComponent.Name,
        Type = investmentComponent.Type
    };
}