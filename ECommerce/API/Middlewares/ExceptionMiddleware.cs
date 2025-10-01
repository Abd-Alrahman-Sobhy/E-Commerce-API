﻿using System.Net;
using System.Text.Json;

namespace API.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception e)
		{
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