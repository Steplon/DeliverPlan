using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliverPlan.Data;
using DeliverPlan.Models;

namespace DeliverPlan.Pages.Tractors
{
    public class DetailsModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public DetailsModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        public Tractor Tractor { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tractor = await _context.Tractor.FirstOrDefaultAsync(m => m.Tag == id);

            if (Tractor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
