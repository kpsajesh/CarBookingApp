using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CareBookingAppData;

namespace CarBookingApp.Pages.Styles
{
    public class DetailsModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public Style Style { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Style = await _context.Styles.FirstOrDefaultAsync(m => m.Id == id);

            if (Style == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
