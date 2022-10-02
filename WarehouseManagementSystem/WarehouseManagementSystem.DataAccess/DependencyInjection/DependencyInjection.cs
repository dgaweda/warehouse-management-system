using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyInjection
{
    public static class RepositoryServiceCollection
    {
        public static IServiceCollection AddDataAccessDI(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(assembly => assembly.Name.EndsWith("Repository") && !assembly.IsAbstract && !assembly.IsInterface)
                .Select(assembly => new { assignedType = assembly, serviceTypes = assembly.GetInterfaces().ToList()})
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });
            
            services.AddDbContext<WMSDatabaseContext>(
                option =>
                    option.UseSqlServer(configuration.GetConnectionString("WMSDatabaseContext")));
            return services;
        }
    }
}