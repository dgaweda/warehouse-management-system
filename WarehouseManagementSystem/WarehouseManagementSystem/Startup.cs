
using System.Linq;
using System.Reflection;
using DataAccess;
using DataAccess.DependencyInjection;
using DataAccess.Entities;
using DataAccess.Repository;
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
using DataAccess.Seeders;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using warehouse_management_system.Authentication;
using warehouse_management_system.Authentication.Privileges;
using warehouse_management_system.Middleware;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Validation.ValidationBehavior;
using WarehouseManagementSystem.ApplicationServices.API.Validation.Validators;
using WarehouseManagementSystem.ApplicationServices.API.Validators;
using WarehouseManagementSystem.ApplicationServices.API.Validators.SeniorityValidators;
using WarehouseManagementSystem.ApplicationServices.Mappings;

namespace warehouse_management_system
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddCors();
            services.AddMvcCore();
            services
                .AddDataAccessDI(Configuration)
                .AddTransient<IPrivilegesService, PrivilegesService>()
                .AddAutoMapper(typeof(UsersProfile).Assembly)
                .AddMediatR(typeof(ResponseBase<>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
                .AddHttpContextAccessor()
                .AddScoped(typeof(IValidatorHelper), typeof(ValidatorHelper))
                .AddValidatorsFromAssembly(typeof(AddSeniorityRequestValidator).Assembly);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                    {
                        DateTimeFormat = "dd'.'MM'.'yyyy HH:mm:ss"
                    };
                    options.SerializerSettings.Converters.Add(dateConverter);
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "warehouse_management_system", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "warehouse_management_system v1"));
            }

            app.UseCors(
                options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                }
            );
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}