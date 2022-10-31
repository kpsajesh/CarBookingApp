using CareBookingAppData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarBookingAppRepositories.Repositories;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp
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
            services.AddDbContext<CarBookingAppDbContext>(options => {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));// ie the type of interface IGenericRepository implemented with the class GenericRepository
            services.AddScoped<ICarModelRepository, CarModelRepository>();// This is the Syntax when the interface and implemantion registered in the IoC container
            services.AddScoped<ICarRepository, CarRepository>();// This is the Syntax when the interface and implemantion registered in the IoC container

            //Anything related to DB operations, make it scoped.
            //Injection Model: AddSingleton - Create only one instance for entire application - Logging to a text file
            //Injection Model: AddScoped - Create one instance till it carry out its operation/set of operations
            //Injection Model: AddTransient - Create one instance with each operation - Sending emails, ie multiple emails to be sent at a time, then multiple instnace to be needed

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
