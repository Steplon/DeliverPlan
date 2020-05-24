using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeliverPlann.Models;
using DeliverPlan.Models;

namespace DeliverPlan.Data
{
    public class DeliverPlanContext : DbContext
    {
        public DeliverPlanContext (DbContextOptions<DeliverPlanContext> options)
            : base(options)
        {
        }

        public DbSet<DeliverPlann.Models.Customer> Customer { get; set; }

        public DbSet<DeliverPlan.Models.Tank> Tank { get; set; }

        public DbSet<DeliverPlan.Models.Tractor> Tractor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(
                "Server=tcp:deliverplandbserver.database.windows.net,1433;Initial Catalog=DeliverPlan_db;Persist Security Info=False;User ID=PlanningAdmin;Password=K0ng0Afr!ca;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
