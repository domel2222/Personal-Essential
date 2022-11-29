﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>//reading about it 
    {
        private readonly ILogger _logger;
        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation($"Personal Essensial Request: {requestName} {request}");

            return Task.CompletedTask; 
        }
    }
}
