using WildOasis.Application;
using WildOasis.Infrastructure;

namespace Api_WildOasis
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddAppliationDI().AddInfrastructureDI();
            return services;
        }
    }
}
