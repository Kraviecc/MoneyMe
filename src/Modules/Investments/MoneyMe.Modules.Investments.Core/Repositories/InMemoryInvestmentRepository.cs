using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Repositories;

internal class InMemoryInvestmentRepository : IInvestmentRepository
{
    private readonly List<Investment> _investments = new();

    public Task<Investment?> GetAsync(Guid id) =>
        Task.FromResult(_investments.SingleOrDefault(p => p.Id == id));

    public async Task<IReadOnlyList<Investment>> GetAllAsync()
    {
        await Task.CompletedTask;

        return _investments;
    }

    public Task AddAsync(Investment investment)
    {
        _investments.Add(investment);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Investment investment)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Investment investment)
    {
        _investments.Remove(investment);

        return Task.CompletedTask;
    }
}