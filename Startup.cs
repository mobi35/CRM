using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveFinance1.Data;
using ActiveFinance1.Data.Model;
using ActiveFinance1.Data.Model.Interface;
using ActiveFinance1.Data.Repository;
using Microsoft.AspNetCore.Builder;
using ActiveFinance1.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ActiveFinance1
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
            services.AddDbContext<AFDBContext>(options => options.UseInMemoryDatabase("AFDBContext"));
            services.AddScoped<IAccountRepository,AccountDetailsRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IPersonalDetailRepository, PersonalDetailRepository>();
            services.AddScoped<ITypeOfLoanRepository, TypeOfLoanRepository>();
            services.AddScoped<IGenericLoanFieldRepository, GenericLoanFieldRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor >();
 
            services.AddSession(so => so.IdleTimeout = TimeSpan.FromSeconds(5000));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static bool IsSessionAvailable;
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IsSessionAvailable = false;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitialize.Seed(app);


        }
    }
}
