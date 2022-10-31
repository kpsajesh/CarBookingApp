using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/
        private readonly ICarRepository _carRepository;
        public IndexModel(ICarRepository CarRepository)
        {
            _carRepository = CarRepository;
        }

        public IList<Car> Cars { get;set; }
        //int intcount;

        public async Task OnGetAsync()
        {
            //Cars = await _context.Cars.ToListAsync();

            /*//Before Adding Repository
            Cars = await _context.Cars
                .Include(q=> q.Make)
                .Include(q => q.Style)
                .Include(q => q.CarModel)
                .ToListAsync();*/
            Cars = await _carRepository.GetCarsWithDetails();
        }
        /*//Before Adding Repository
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            var Car = await _context.Cars.FindAsync(RecordId);

            if (Car != null)
            {
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            await _carRepository.Delete(RecordId.Value);

            return RedirectToPage("./Index");
        }

    }
}
