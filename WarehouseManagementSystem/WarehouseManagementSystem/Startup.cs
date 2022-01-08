using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.PalletCommands;
using DataAccess.CQRS.Queries;
using DataAccess.CQRS.Queries.RoleQueries;
using DataAccess.Entities;
using DataAccess.Repository;
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
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Validators;
using WarehouseManagementSystem.ApplicationServices.API.Validators.Seniority;
using WarehouseManagementSystem.ApplicationServices.Mappings;

namespace warehouse_management_system
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddSeniorityRequestValidator>());

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddScoped(typeof(IGetEntityHelper<Role>), typeof(GetRolesHelper));
            services.AddTransient<IPalletPropertiesSetter, PalletPropertiesSetter>();
            //services.AddScoped(typeof(ICommandHandler<,,,,>), typeof(CommandHandler<,,,,>));

            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddAutoMapper(typeof(UsersProfile).Assembly); // This Line Enables AutoMapper to map all profiles without adding everyone of them.
                                                                       // It gets Assembly from one profile to get all the mappings.
            services.AddMediatR(typeof(ResponseBase<>));

            services.AddDbContext<WMSDatabaseContext>(
                option =>
                option.UseSqlServer(this.Configuration.GetConnectionString("WMSDatabaseContext")));

            services.AddScoped(typeof(IValidatorHelper<>), typeof(ValidatorHelper<>));

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

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}