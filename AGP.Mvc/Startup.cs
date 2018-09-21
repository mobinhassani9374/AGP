using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AGP.DataLayer.Repositories;

namespace AGP.Mvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(env.ContentRootPath)
                           .AddJsonFile("appsetting.json");
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataLayer.AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc();

            // repository and Servcie Injection
            services.AddScoped<UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region database initializer
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataLayer.AppDbContext>();
                context.Database.Migrate();
                new DataLayer.DatabaseInitializer(context).SeedData();
            }

            #endregion

            app.UseMvcWithDefaultRoute();
        }
    }
}
