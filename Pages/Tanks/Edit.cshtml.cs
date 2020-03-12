using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliverPlan.Data;
using DeliverPlan.Models;

namespace DeliverPlan.Pages.Tanks
{
    public class EditModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public EditModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tank Tank { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tank = await _context.Tank.FirstOrDefaultAsync(m => m.Tag == id);

            if (Tank == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TankExists(Tank.Tag))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TankExists(string id)
        {
            return _context.Tank.Any(e => e.Tag == id);
        }
    }
}
