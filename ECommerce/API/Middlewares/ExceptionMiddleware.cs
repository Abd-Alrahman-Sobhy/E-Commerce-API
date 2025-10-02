using System.Net;
using System.Text.Json;

namespace API.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger = null)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception e)
		{
			_logger.LogCritical("Something went wrong: {Message}", e.Message);
			await HandleExceptionAsync(context, e);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		var response = new
		{
			statusCode = context.Response.StatusCode,
			message = exception.Message,
		};

		await context.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
}