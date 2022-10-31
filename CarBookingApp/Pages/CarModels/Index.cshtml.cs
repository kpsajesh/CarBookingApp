using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/
        private readonly ICarModelRepository _carModelRepository;
        public IndexModel(ICarModelRepository CarModelRepository)
        {
            _carModelRepository = CarModelRepository;
        }

        public IList<CarModel> CarModel { get; set; }

        public async Task OnGetAsync()
        {
            /*//Before Adding Repository
            CarModel = await _context.CarModels
                .Include(m => m.Make)
                .ToListAsync();*/

            CarModel = await _carModelRepository.GetCarsWithDetails();

        }
        /*//Before Adding Repository
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
        }*/
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            await _carModelRepository.Delete(RecordId.Value);

            return RedirectToPage("./Index");
        }

    }
}
