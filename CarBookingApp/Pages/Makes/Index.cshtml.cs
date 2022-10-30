using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CareBookingAppData;

namespace CarBookingApp.Pages.Makes
{
    public class IndexModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; }

        public async Task OnGetAsync()
        {
            Make = await _context.Makes.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            var Make = await _context.Makes.FindAsync(RecordId);

            if (Make != null)
            {
                _context.Makes.Remove(Make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
