using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;

namespace CarBookingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get;set; }
        //int intcount;

        public async Task OnGetAsync()
        {
            //Cars = await _context.Cars.ToListAsync();
            Cars = await _context.Cars
                .Include(q=> q.Make)
                .Include(q => q.Style)
                .Include(q => q.CarModel)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? CarId)
        {
            if (CarId == null)
            {
                return NotFound();
            }

            var Car = await _context.Cars.FindAsync(CarId);

            if (Car != null)
            {
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
        
    }
}
