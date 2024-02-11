using General.Business.Managers.Service;
using General.Business.Managers.Tangella;
using General.Business.Managers.Tangella.Employee;
using General.Business.Managers.Tangella.TEventWithWorkAddress;
using General.Business.Managers.Tangella.TFreeTimeSlots;
using General.Data.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using General.Business.Managers.Tangella.TWebOrder;
using General.Business.Managers.Prices;
//using General.Business.Managers.Customer;
//using General.Business.Managers.JiffyTidyManagers.Employee;
using AutoMapper;
using General.Domain.Profiles;
using General.Business.Managers.KsStad.Prices;
using General.Business.Managers.KsStad.AdditionalService;
using General.Business.Managers.KsStad.Service;
using General.Business.Managers.KsStad.Employee;
using General.Business.Managers.KsStad.Order;
using General.Business.Managers.KsStad.Customer;
using General.Business.Managers.KsStad.WindowType;
using General.Business.Managers.KsStad.Project;
using General.Business.Managers.Tangella.TSupervisor;
using General.Business.Managers.KsStad.Supervisor;
using General.Business.Managers.KsStad.SupervisorRole;
using System;
using System.Text;
using System.Net.Http.Headers;
using General.Business.Managers.Tangella.V2.Token;
using General.Business.Managers.Tangella.V2.Customer;
using General.Business.Managers.Tangella.V2.Project;
using General.Business.Managers.Tangella.TProject;
using General.Business.Managers.Tangella.V2.Order;

namespace general.api
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
            services.AddScoped<DataContext>();
            services.AddHttpClient("tgV2", c =>
            {
                c.BaseAddress = new Uri("https://api.tengella.se/public/v2/");
                c.Timeout = new TimeSpan(0, 3, 0);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddAutoMapper(
                typeof(ServiceProfile),
                typeof(Startup));
            // Auto Mapper Configurations

            // Tangella Managers Start
            services.AddScoped<ITEmployeeManager, TEmployeeManager>();
            services.AddScoped<ITEventWithWorkAddress, TEventWithWorkAddress>();
            services.AddScoped<ITFreeTimeslotsManager, TFreeTimeslotsManager>();
            services.AddScoped<ITWebOrderManager, TWebOrderManager>();
            services.AddScoped<ITSupervisorManager, TSupervisorManager>();
            services.AddScoped<ITProjectManager, TProjectManager>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderRowManager, OrderRowManager>();
            // Tangella Managers End

            services.AddScoped<IKsEmployeeManager, KsEmployeeManager>();
            services.AddScoped<IKsServiceManager, KsServiceManager>();
            services.AddScoped<IKsPriceManager, KsPriceManager>();
            services.AddScoped<IKsAdditionalServiceManager, KsAdditionalServiceManager>();
            services.AddScoped<IKsWindowTypeManager, KsWindowTypeManager>();
            services.AddScoped<IKsProjectManager, KsProjectManager>();
            services.AddScoped<IKsSupervisorManager, KsSupervisorManager>();
            services.AddScoped<IKsSupervisorRoleManager, KsSupervisorRoleManager>();
            services.AddScoped<IKsCustomerManager, KsCustomerManager>();
            services.AddScoped<IKsOrderManager, KsOrderManager>();

            // JiffyTidy managers start
            //services.AddScoped<IEmployeeManager, EmployeeManager>();

            //JiffyTidy managers end
            services.AddCors();
            // Prevent reference loop
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerDocument();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8080", "http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
