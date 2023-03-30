﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoneyMe.Shared.Abstractions.Exceptions;
using System.Net;

namespace MoneyMe.Shared.Infrastructure.Exceptions;

internal class ErrorHandlerMiddleware : IMiddleware
{
	private readonly ILogger<ErrorHandlerMiddleware> _logger;
	private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

	public ErrorHandlerMiddleware(
		ILogger<ErrorHandlerMiddleware> logger,
		IExceptionCompositionRoot exceptionCompositionRoot)
	{
		_logger = logger;
		_exceptionCompositionRoot = exceptionCompositionRoot;
	}

	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, exception.Message);
			await HandleErrorAsync(context, exception);
		}
	}

	private async Task HandleErrorAsync(HttpContext context, Exception exception)
	{
		var errorResponse = _exceptionCompositionRoot.Map(exception);

		context.Response.StatusCode = (int)(errorResponse?.Code ?? HttpStatusCode.InternalServerError);
		var response = errorResponse?.Response;

		if (response is null)
		{
			return;
		}

		await context.Response.WriteAsJsonAsync(response);
	}
}