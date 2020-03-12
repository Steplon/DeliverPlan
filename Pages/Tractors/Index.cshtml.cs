﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly DeliverPlan.Data.DeliverPlanContext _context;

        public IndexModel(DeliverPlan.Data.DeliverPlanContext context)
        {
            _context = context;
        }

        public IList<Tractor> Tractor { get;set; }

        public async Task OnGetAsync()
        {
            Tractor = await _context.Tractor.ToListAsync();
        }
    }
}
