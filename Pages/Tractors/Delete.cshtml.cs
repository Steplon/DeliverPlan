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
    public class DeleteModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public DeleteModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tractor = await _context.Tractor.FindAsync(id);

            if (Tractor != null)
            {
                _context.Tractor.Remove(Tractor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
