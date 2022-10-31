using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;
using CarBookingAppData;

namespace CarBookingApp.Pages.CarModels
{
    public class EditModel : PageModel
    {


        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public EditModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/

        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<Make> _carMakeRepository;
        public EditModel(IGenericRepository<CarModel> CarModelRepository, IGenericRepository<Make> CarMakeRepository)
        {
            this._carModelRepository = CarModelRepository;
            this._carMakeRepository = CarMakeRepository;
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Makes { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            CarModel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);*/

            CarModel = await _carModelRepository.Get(id.Value);

            if (CarModel == null)
            {
                return NotFound();
            }

            await LoadDDL();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDDL();
                return Page();
            }

            CarModel.UpdatedBy = "Sajesh";
            CarModel.CreatedBy = "Sajesh";
            //CarModel.UpdatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.Attach(CarModel).State = EntityState.Modified;
            //NoContentResult code added here*/

            try
            {
                /*//Before Adding Repository
                await _context.SaveChangesAsync();*/

                await _carModelRepository.Update(CarModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*//Before Adding Repository
                if (!CarModelExists(CarModel.Id))*/ // Changed to Async
                if (!await CarModelExistsAsync(CarModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /*//Before Adding Repository
        private bool CarModelExists(int id) // Changed to Async below
        {
            
            return _context.CarModels.Any(e => e.Id == id);
        }*/

        private async Task<bool> CarModelExistsAsync(int id)
        {

            return await _carModelRepository.Exists(id);
        }
            
        private async Task LoadDDL()
        {
            /*//Before Adding Repository
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");*/
            Makes = new SelectList(await _carMakeRepository.GetAll(), "Id", "Name");
        }
    }
}
