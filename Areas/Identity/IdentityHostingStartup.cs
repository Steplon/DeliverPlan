using System;
using DeliverPlan.Areas.Identity.Data;
using DeliverPlan.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DeliverPlan.Areas.Identity.IdentityHostingStartup))]
namespace DeliverPlan.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DeliverPlanUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AzureSQLServerDatabase")));

                services.AddDefaultIdentity<DeliverPlanUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DeliverPlanUserContext>();
            });
        }
    }
}