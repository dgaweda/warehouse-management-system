
using DataAccess;
using DataAccess.CQRS;
using DataAccess.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
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
using warehouse_management_system.Middleware;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.PipelineBehavior;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers;
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

            
                // .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddSeniorityRequestValidator>());

            services.AddTransient<IQueryExecutor, QueryExecutor>();

            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddTransient<IPrivilegesService, PrivilegesService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddAutoMapper(typeof(UsersProfile).Assembly); // This Line Enables AutoMapper to map all profiles without adding everyone of them.
            // It gets Assembly from one profile to get all the mappings.
            services.AddMediatR(typeof(ResponseBase<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddHttpContextAccessor();

            services.AddDbContext<WMSDatabaseContext>(
                option =>
                    option.UseSqlServer(Configuration.GetConnectionString("WMSDatabaseContext")));

            services.AddScoped(typeof(IValidatorHelper), typeof(ValidatorHelper));
            services.AddValidatorsFromAssembly(typeof(AddSeniorityRequestValidator).Assembly);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                    {
                        DateTimeFormat = "dd'.'MM'.'yyyy HH:mm:ss"
                    };
                    options.SerializerSettings.Converters.Add(dateConverter);
                });
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy(Enum.GetName(RoleKey.WAREHOUSEMAN),
            //         policy => policy.RequireClaim("Privileges", PrivilegesService.GetWarehouseManPrivileges()));
            //     options.AddPolicy(Enum.GetName(RoleKey.GENERAL_ADMIN),
            //         policy => policy.RequireClaim("Privileges", PrivilegesService.GetGeneralAdminPrivileges()));
            //     options.AddPolicy(Enum.GetName(RoleKey.GENERAL_ADMIN),
            //         policy => policy.RequireClaim("Privileges", PrivilegesService.GetManagerPrivileges()));
            // });
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