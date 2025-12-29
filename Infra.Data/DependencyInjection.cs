using Infra.Data.Repositories;
using Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(new MySqlConnectionString(config.GetConnectionString("DefaultConnection")!));
            services.AddScoped<ConnectionContext>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
