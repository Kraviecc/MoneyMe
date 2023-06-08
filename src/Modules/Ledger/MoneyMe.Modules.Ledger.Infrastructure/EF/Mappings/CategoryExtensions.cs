using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Modules.Ledger.Domain.Categories.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;

internal static class CategoryExtensions
{
	public static CategoryDto AsDto(this Category category)
	{
		return new()
		{
			Id = category.Id,
			InvestmentId = category.InvestmentId,
			Name = category.Name,
			Type = category.Type
		};
	}
}