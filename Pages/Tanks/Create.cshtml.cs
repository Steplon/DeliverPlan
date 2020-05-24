using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliverPlan.Data;
using DeliverPlan.Models;
using DeliverPlann.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliverPlan.Pages.Tanks
{
    public class CreateModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public CreateModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Customers { get; set; }

        public IActionResult OnGet()
        {
            Customers = _context.Customer.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.ID,
                                      Text = a.CompanyName
                                  }).ToList();

            return Page();
        }

        [BindProperty]
        public Tank Tank { get; set; }



        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (Tank.CustomerID == null)
            //{
            //    return NotFound();
            //}

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tank.Add(Tank);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
