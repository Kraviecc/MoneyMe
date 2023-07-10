using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Exceptions;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.Services;

internal class InvestmentContributorService : IInvestmentContributorService
{
    private readonly IInvestmentContributorRepository _investmentContributorRepository;
    private readonly IInvestmentComponentRepository _investmentComponentRepository;

    public InvestmentContributorService(
        IInvestmentContributorRepository investmentContributorRepository,
        IInvestmentComponentRepository investmentComponentRepository)
    {
        _investmentContributorRepository = investmentContributorRepository;
        _investmentComponentRepository = investmentComponentRepository;
    }

    public async Task AddAsync(InvestmentContributorDto dto)
    {
        var investmentComponent = await _investmentComponentRepository.GetAsync(dto.InvestmentComponentId);
        if (investmentComponent is null)
        {
            throw new InvestmentComponentNotFoundException(dto.InvestmentComponentId);
        }

        dto.Id = Guid.NewGuid();
        await _investmentContributorRepository.AddAsync(new InvestmentContributor
        {
            Id = dto.Id,
            Type = dto.Type,
            InvestmentComponentId = dto.InvestmentComponentId,
            InvestmentContributorId = dto.InvestmentContributorId
        });
    }

    public async Task<IReadOnlyList<InvestmentContributorDetailsDto>> GetAsync(Guid investmentComponentId)
    {
        var contributors = await _investmentContributorRepository.GetByInvestmentComponentAsync(investmentComponentId);

        return contributors
            .Select(Map<InvestmentContributorDetailsDto>)
            .ToList();
    }

    public async Task DeleteAsync(Guid investmentContributorId)
    {
        var contributor = await _investmentContributorRepository.GetAsync(investmentContributorId);
        if (contributor is null)
        {
            return;
        }

        await _investmentContributorRepository.DeleteAsync(contributor);
    }

    private static T Map<T>(InvestmentContributor investmentContributor) where T : InvestmentContributorDto, new() =>
        new()
        {
            Id = investmentContributor.Id,
            Type = investmentContributor.Type,
            InvestmentComponentId = investmentContributor.InvestmentComponentId,
            InvestmentContributorId = investmentContributor.InvestmentContributorId
        };
}