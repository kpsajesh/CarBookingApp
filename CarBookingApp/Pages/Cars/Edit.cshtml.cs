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
using CarBookingAppRepositories.Repositories;

namespace CarBookingApp.Pages.Cars
{
    public class EditModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public EditModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/
        //This is the repository code
        private readonly ICarRepository _carRepository;
        private readonly IGenericRepository<Make> _carMakeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IGenericRepository<Style> _carSyleRepository;

        public EditModel(ICarRepository CarRepository,
            IGenericRepository<Make> CarMakeRepository,
            ICarModelRepository CarModelRepository,
            IGenericRepository<Style> CarSyleRepository
            )
        {
            this._carRepository = CarRepository;
            this._carMakeRepository = CarMakeRepository;
            this._carModelRepository = CarModelRepository;
            this._carSyleRepository = CarSyleRepository;
        }

        [BindProperty]
        public Car Cars { get; set; }
        public SelectList Makes { get; set; }
        public SelectList Styles { get; set; }
        public SelectList CarModels { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            Cars = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);*/

            //This is the repository code
            Cars = await _carRepository.Get(id.Value);


            if (Cars == null)
            {
                return NotFound();
            }

            /*Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
            Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");*/
            await LoadDDL();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            /*if (await _carRepository.IsNumberPlateExists(Cars.RegnNo))
            {
                ModelState.AddModelError(nameof(Cars.RegnNo), "License plate number exists already.");
            }*/
            if (!ModelState.IsValid)
            {
                /*Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
                Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");*/
                await LoadDDL();
                return Page();
            }

            Cars.UpdatedBy = "Sajesh";
            Cars.UpdatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.Attach(Cars).State = EntityState.Modified;
            //No new code here*/

            try
            {
                /* //Before Adding Repository
                 await _context.SaveChangesAsync();*/

                //This is the repository code
                await _carRepository.Update(Cars);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Before Adding Repository
                //if (!CarExists(Cars.Id))
                 if (! await CarExistsAsync(Cars.Id))// changed to async return with await
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
        /* //Before Adding Repository
         private bool CarExists(int id)
         {
             return _context.Cars.Any(e => e.Id == id);
         }*/
        //This is the repository code
        private async Task<bool> CarExistsAsync(int id)// made this method to Async
        {
            return await _carRepository.Exists(id);
        }
        /*//Before Adding Repository
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Styles = new SelectList(await _context.Styles.ToListAsync(), "Id", "Name");
            CarModels = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
        }*/

        //This is the repository code
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _carMakeRepository.GetAll(), "Id", "Name");
            Styles = new SelectList(await _carSyleRepository.GetAll(), "Id", "Name");
            //CarModels = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
        }
        /*//Before Adding Repository
        public async Task<JsonResult> OnGetCarModels(int PKtoPass)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == PKtoPass)
                .ToListAsync();

            return new JsonResult(models);
        }*/

        //This is the repository code
        public async Task<JsonResult> OnGetCarModels(int PKtoPass)
        {
            return new JsonResult(await _carModelRepository.GetCarModelBymake(PKtoPass));
        }
    }
}
