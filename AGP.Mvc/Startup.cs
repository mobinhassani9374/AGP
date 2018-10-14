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
using Microsoft.AspNetCore.Authentication.Cookies;
using AGP.Mvc.Middleware;
using AutoMapper;
using AGP.Infrastructure.Mapping;
using AGP.Domain.DTO;
using AGP.Payment.Bitpay;

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

            AppSettingProvider.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        public IConfigurationRoot Configuration { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            services.AddDbContext<DataLayer.AppDbContext>(options =>
            {
                options.UseSqlServer(AppSettingProvider.ConnectionString);
            });
            services.AddAutoMapper();
            services.AddHttpClient();
            // init auto Mapper
            Initialize.Init();
            // end init auto Mapper
            services.AddMvc();

            // configuration file Injection
            services.AddSingleton<IConfigurationRoot>(config => { return Configuration; });
            services.Configure<BitPayConfig>(options => Configuration.GetSection("BitPayConfig").Bind(options));

            // repository and Servcie Injection
            services.AddScoped<UserManager>();
            services.AddScoped<LogServiceRepository>();
            services.AddScoped<GameRepository>();
            services.AddScoped<AccountGameRepository>();
            services.AddScoped<AdminExtraRepository>();
            services.AddScoped<TransacionRepository>();
            services.AddScoped<UserAccountGameRepository>();
            services.AddScoped<PayService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            #region database initializer
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataLayer.AppDbContext>();
                context.Database.Migrate();
                new DataLayer.DatabaseInitializer(context).SeedData();
            }

            #endregion

            app.UseMiddleware<LogServiceMiddleware>();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseMvcWithDefaultRoute();
        }
    }
}
