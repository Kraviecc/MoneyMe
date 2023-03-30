using System.Net;

namespace MoneyMe.Shared.Abstractions.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode Code);