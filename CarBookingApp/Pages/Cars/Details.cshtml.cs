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
    public class DetailsModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/
        private readonly ICarRepository _carRepository;
        public DetailsModel(ICarRepository CarRepository)
        {
            _carRepository = CarRepository;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            /*//Before Adding Repository
            Car = await _context.Cars
                .Include(q=> q.Make)
                .Include(q => q.Style)
                .Include(q => q.CarModel)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            Car = await _carRepository.GetCarWithDetails(id.Value);
                       

            if (Car == null)
            {
                return NotFound();
            }
           
            return Page();
        }
    }
}
