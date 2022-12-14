using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwimmingPoolNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//using SwimmingPoolNew.DbInitializer;
using SwimmingPoolNew.Models;
//using SwimmingPoolNew.Services;
using SwimmingPoolNew.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using SwimmingPoolNew.Services;

namespace SwimmingPoolNew
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
             //?? throw new InvalidOperationException("Connection string 'SwimmingPoolContext' not found.")));
            services.AddDbContext<SwimmingPoolContext>
                (option => option.UseSqlServer(Configuration.GetConnectionString("SwimmingPoolContext")));
            services.AddControllersWithViews();

            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SwimmingPoolContext>();
            services.AddHttpContextAccessor();
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
            app.UseAuthentication();
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
