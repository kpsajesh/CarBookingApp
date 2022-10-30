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
    public class IndexModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Style> Styles { get;set; }

        public async Task OnGetAsync()
        {
            Styles = await _context.Styles.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            var Style = await _context.Styles.FindAsync(RecordId);

            if (Style != null)
            {
                _context.Styles.Remove(Style);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
