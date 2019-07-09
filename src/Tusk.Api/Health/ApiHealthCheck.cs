using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Tusk.Application;

namespace Tusk.Api.Health
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly IProjectRepository repository;

        public ApiHealthCheck(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var isHealthy = await repository.Check();
                if(!isHealthy)
                {
                    return HealthCheckResult.Healthy("Database connection is working.");
                }
                return HealthCheckResult.Unhealthy("The connection to the database is unhealthy.", new System.IO.FileNotFoundException("Just a test"));
            }
            catch (System.Exception ex)
            {
                return HealthCheckResult.Unhealthy("The connection to the database is caused an error.", ex);
            }
            
        }
    }
}