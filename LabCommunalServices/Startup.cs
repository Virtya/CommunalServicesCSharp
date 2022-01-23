using AutoMapper;
using Business.Repositories;
using Business.Repositories.DataRepository;
using Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCommunalServices
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IConfigurationRoot _configuration;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region common 
            services.AddSingleton<IConfiguration>(_configuration);

            services.AddDbContext<Context>(
                options => options
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")),
                contextLifetime: ServiceLifetime.Singleton,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ILawRepository, LawRepository>();
            services.AddScoped<IPaymentDocRepository, PaymentDocRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            #endregion

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ILawService, LawService>();
            services.AddScoped<IPaymentDocService, PaymentDocService>();
            services.AddScoped<IServiceService, ServiceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
