using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliverPlan.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeliverPlan.Data
{
    public class DeliverPlanUserContext : IdentityDbContext<DeliverPlanUser>
    {
        public DeliverPlanUserContext(DbContextOptions<DeliverPlanUserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:deliverplandbserver.database.windows.net,1433;Initial Catalog=DeliverPlan_db;Persist Security Info=False;User ID=PlanningAdmin;Password=K0ng0Afr!ca;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}