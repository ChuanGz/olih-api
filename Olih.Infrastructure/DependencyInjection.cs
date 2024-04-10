using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olih.Domain.Interfaces;
using Olih.Infrastructure.Services;

namespace Olih.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            return services.AddScoped<IBranchService, BranchService>();
        }
    }
}
