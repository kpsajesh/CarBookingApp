using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareBookingAppData;
using Microsoft.EntityFrameworkCore;
using CarBookingAppRepositories.Contracts;
using CarBookingAppData;

namespace CarBookingApp.Pages.CarModels
{
    public class CreateModel : PageModel
    {


        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<Make> _carMakeRepository;
        public CreateModel(IGenericRepository<CarModel> CarModelRepository, 
            IGenericRepository<Make> CarmakeRepository)
        {
           this._carModelRepository = CarModelRepository;
           this._carMakeRepository = CarmakeRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadDDL();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Makes { get; private set; }
        public IGenericRepository<Make> CarmakeRepository { get; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDDL();
                return Page();
            }


            CarModel.CreatedBy = "Sajesh";
            //CarModel.CreatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.CarModels.Add(CarModel);
            await _context.SaveChangesAsync();*/

            await _carModelRepository.Insert(CarModel);

            return RedirectToPage("./Index");
        }
        private async Task LoadDDL()
        {
            /*//Before Adding Repository
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");*/

            Makes = new SelectList(await _carMakeRepository.GetAll(), "Id", "Name");
        }
    }

}
