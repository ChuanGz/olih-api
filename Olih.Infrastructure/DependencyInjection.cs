using Microsoft.Extensions.DependencyInjection;
using Olih.Domain.Interfaces.Services;
using Olih.Infrastructure.Services;

namespace Olih.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IBusinessPartnerService, BusinessPartnerService>();
        services.AddScoped<IItemMasterDataService, ItemMasterDataService>();

        return services;
    }
}
