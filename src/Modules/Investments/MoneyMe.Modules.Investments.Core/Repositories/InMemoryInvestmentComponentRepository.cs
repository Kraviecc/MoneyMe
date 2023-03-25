using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Repositories;

internal class InMemoryInvestmentComponentRepository : IInvestmentComponentRepository
{
	private readonly List<InvestmentComponent> _investmentComponents = new();

	public Task<InvestmentComponent?> GetAsync(Guid id) =>
		Task.FromResult(_investmentComponents.SingleOrDefault(p => p.Id == id));

	public async Task<IReadOnlyList<InvestmentComponent>> GetAllAsync()
	{
		await Task.CompletedTask;

		return _investmentComponents;
	}

	public Task AddAsync(InvestmentComponent investmentComponent)
	{
		_investmentComponents.Add(investmentComponent);

		return Task.CompletedTask;
	}

	public Task UpdateAsync(InvestmentComponent investmentComponent)
	{
		return Task.CompletedTask;
	}

	public Task DeleteAsync(InvestmentComponent investmentComponent)
	{
		_investmentComponents.Remove(investmentComponent);

		return Task.CompletedTask;
	}
}