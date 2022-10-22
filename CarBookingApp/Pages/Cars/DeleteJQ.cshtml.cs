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
    public class DeleteJQModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public DeleteJQModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Cars.ToListAsync();
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
