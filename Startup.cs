using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DeliverPlan.Data;
using DeliverPlan.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DeliverPlan
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
            //services.AddRazorPages();

            services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        //allow access to these folders by logged in users only
        options.Conventions.AuthorizeFolder("/Tanks");
        options.Conventions.AuthorizeFolder("/Customers");
        options.Conventions.AuthorizeFolder("/Tractors");
    });

            services.AddDbContext<DeliverPlanContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AzureSQLServerDatabase")));

            services.BuildServiceProvider().GetService<DeliverPlanUserContext>().Database.Migrate();
            services.BuildServiceProvider().GetService<DeliverPlanContext>().Database.Migrate();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
