using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliverPlan.Data;
using DeliverPlann.Models;

namespace DeliverPlan.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public DetailsModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
