using Humanizer;
using MoneyMe.Shared.Abstractions.Exceptions;
using System.Collections.Concurrent;
using System.Net;

namespace MoneyMe.Shared.Infrastructure.Exceptions;

internal class ExceptionToResponseMapper : IExceptionToResponseMapper
{
	private static readonly ConcurrentDictionary<Type, string> Codes = new();

	public ExceptionResponse? Map(Exception exception) => exception switch
	{
		MoneyMeException ex => new ExceptionResponse(
			new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)),
			HttpStatusCode.InternalServerError),
		_ => new ExceptionResponse(
			new ErrorsResponse(new Error("error", "There was an error.")),
			HttpStatusCode.BadRequest)
	};

	private record Error(string Code, string Message);

	private record ErrorsResponse(params Error[] Errors);

	private static string GetErrorCode(object exception)
	{
		var type = exception.GetType();

		return Codes.GetOrAdd(
			type,
			type.Name.Underscore().Replace("_exception", string.Empty));
	}
}