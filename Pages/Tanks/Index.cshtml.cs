using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliverPlan.Data;
using DeliverPlan.Models;

namespace DeliverPlan.Pages.Tanks
{
    public class IndexModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public IndexModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        public IList<Tank> Tanks { get;set; }

        public async Task OnGetAsync()
        {
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-3.1&tabs=visual-studio

            Tanks = await _context.Tank.ToListAsync();
            
        }
    }
}
