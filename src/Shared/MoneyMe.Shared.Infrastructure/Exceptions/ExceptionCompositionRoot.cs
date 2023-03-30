using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Shared.Infrastructure.Exceptions;

internal class ExceptionCompositionRoot : IExceptionCompositionRoot
{
	private readonly IServiceProvider _serviceProvider;

	public ExceptionCompositionRoot(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public ExceptionResponse Map(Exception exception)
	{
		using var scope = _serviceProvider.CreateScope();
		var mappers = _serviceProvider
		   .GetServices<IExceptionToResponseMapper>()
		   .ToArray();

		var nonDefaultMappers = mappers.Where(p => p is not ExceptionToResponseMapper);
		var result = nonDefaultMappers
		   .Select(p => p.Map(exception))
		   .SingleOrDefault(p => p is not null);

		if (result is not null)
		{
			return result;
		}

		var defaultMapper = mappers.SingleOrDefault(p => p is ExceptionToResponseMapper);

		return defaultMapper!.Map(exception)!;
	}
}