using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<NorthwindContext>(options => options.UseNpgsql(configuration.GetConnectionString("Northwind")));
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Northwind")));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerDemographicRepository, CustomerDemographicRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<IShipperRepository, ShipperRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ITerritoryRepository, TerritoryRepository>();
        services.AddScoped<IUsStateRepository, UsStateRepository>();
        return services;
    }
}
