using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareBookingAppData;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
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

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(),"Id", "Name");
            Styles = new SelectList(await _context.Styles.ToListAsync(), "Id", "Name");
            CarModels = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
        }
    }
}
