using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;

namespace CarBookingApp.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModel { get; set; }

        public async Task OnGetAsync()
        {
            CarModel = await _context.CarModels
                .Include(m => m.Make)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            var CarModel = await _context.CarModels.FindAsync(RecordId);

            if (CarModel != null)
            {
                _context.CarModels.Remove(CarModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
