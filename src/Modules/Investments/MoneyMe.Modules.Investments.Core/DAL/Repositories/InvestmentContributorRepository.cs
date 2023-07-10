using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.DAL.Repositories;

internal class InvestmentContributorRepository : IInvestmentContributorRepository
{
    private readonly InvestmentsDbContext _context;
    private readonly DbSet<InvestmentContributor> _investmentContributors;

    public InvestmentContributorRepository(InvestmentsDbContext context)
    {
        _context = context;
        _investmentContributors = context.InvestmentContributors;
    }

    public async Task<InvestmentContributor?> GetAsync(Guid investmentContributorId)
        => await _investmentContributors.FirstOrDefaultAsync(p => p.Id == investmentContributorId);

    public async Task<IReadOnlyList<InvestmentContributor?>>
        GetByInvestmentComponentAsync(Guid investmentComponentId) => await _investmentContributors
        .Where(p => p.InvestmentComponentId == investmentComponentId)
        .ToListAsync();

    public async Task AddAsync(InvestmentContributor investmentContributor)
    {
        await _investmentContributors.AddAsync(investmentContributor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(InvestmentContributor investmentContributor)
    {
        _investmentContributors.Remove(investmentContributor);
        await _context.SaveChangesAsync();
    }
}