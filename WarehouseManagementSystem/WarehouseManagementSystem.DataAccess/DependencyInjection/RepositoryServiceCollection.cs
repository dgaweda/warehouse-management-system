using DataAccess.Repository.DeliveryRepository;
using DataAccess.Repository.DepartureRepository;
using DataAccess.Repository.InvoiceRepository;
using DataAccess.Repository.LocationRepository;
using DataAccess.Repository.OrderLineRepository;
using DataAccess.Repository.OrderRepository;
using DataAccess.Repository.PalletRepository;
using DataAccess.Repository.ProductPalletLineRepository;
using DataAccess.Repository.ProductRepository;
using DataAccess.Repository.RoleRepository;
using DataAccess.Repository.SeniorityRepository;
using DataAccess.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyInjection
{
    public static class RepositoryServiceCollection
    {
        public static IServiceCollection AddRepositoryServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDepartureRepository, DepartureRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISeniorityRepository, SeniorityRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductPalletLineRepository, ProductPalletLineRepository>();
            services.AddScoped<IPalletRepository, PalletRepository>();
            return services;
        }
    }
}