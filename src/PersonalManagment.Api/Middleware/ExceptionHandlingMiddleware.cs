using Azure;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApplicationException = Domain.Exceptions.ApplicationException;
using Error = Domain.Shared.Error;

namespace PersonalManagment.Api.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(context, exception);
            }  
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detatil = exception.Message,
                errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            var json = JsonConvert.SerializeObject(response);

            await httpContext.Response.WriteAsync(json);
        }

        private static IEnumerable<Error> GetErrors(Exception exception)
        {
            IEnumerable<Error> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        }

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.Title,
                _ => "Server Error"
            };

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
