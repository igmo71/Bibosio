﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibosio.Common.Exceptions
{
    public sealed class AppBadRequestExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<AppBadRequestExceptionHandler> _logger;

        public AppBadRequestExceptionHandler(ILogger<AppBadRequestExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not AppBadRequestException badRequestException)
            {
                return false;
            }

            _logger.LogError(badRequestException, "Exception occurred: {Message}", badRequestException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = badRequestException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }

}