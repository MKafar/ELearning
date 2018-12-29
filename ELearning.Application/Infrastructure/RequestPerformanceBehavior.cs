using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ELearning.Application.Infrastructure
{
    public class RequestPerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehavior(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if(_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                // TODO Add User Details

                _logger.LogWarning("ELearning Long Running Request: {Name} ({ElapsedMiliseconds} miliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}
