using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
	ExceptionResponse Map(Exception exception);
}