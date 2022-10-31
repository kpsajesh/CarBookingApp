using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;
using CarBookingAppRepositories.Repositories;

namespace CarBookingApp.Pages.CarModels
{
    public class DetailsModel : PageModel
    {


        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/
        private readonly ICarModelRepository _carModelRepository;
        public DetailsModel(ICarModelRepository CarModelRepository)
        {
            _carModelRepository = CarModelRepository;
        }
        public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            CarModel = await _context.CarModels
                .Include(m => m.Make)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            CarModel = await _carModelRepository.GetCarModelWithDetail(id.Value);

            if (CarModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
