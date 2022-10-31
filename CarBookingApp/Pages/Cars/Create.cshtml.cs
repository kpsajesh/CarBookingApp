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
using CarBookingAppRepositories.Repositories;

namespace CarBookingApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }*/

        //This is the repository code
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Make> _carMakeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IGenericRepository<Style> _carSyleRepository;

        public CreateModel(IGenericRepository<Car> CarRepository,
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
        public Car Car { get; set; }
        public SelectList Makes { get; set; }
        public SelectList Styles { get; set; }
        public SelectList CarModels { get; set; }

        public async Task<IActionResult> OnGet()
        {
            /*Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
            Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");*/
            await LoadDDL();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                /*Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
                Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");*/
                await LoadDDL();
                return Page();
            }
            Car.CreatedBy = "Sajesh";
            Car.CreatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();*/

            //This is the repository code
            await _carRepository.Insert(Car);

            return RedirectToPage("./Index");
        }
        /*//Before Adding Repository
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Styles = new SelectList(await _context.Styles.ToListAsync(), "Id", "Name");
            //CarModels = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
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

        /*//Before Adding Repository
        public async Task<JsonResult> OnGetCarModels2(int id)
        {
            var ptwrscList = await (from a in _context.CarModels
                                    where a.MakeId == id
                                    select a).ToListAsync();

            return new JsonResult(new SelectList(ptwrscList, "id", "name"));
        }*/

        /*public async Task<int> OnGetCarModels2()
        {
            DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);

            int leisureHours =
                today is DayOfWeek.Saturday || today is DayOfWeek.Sunday
                ? 16 : 5;

            return leisureHours;
        }*/
    }
}
