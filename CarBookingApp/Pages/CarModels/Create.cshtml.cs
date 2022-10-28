using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareBookingAppData;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadDDL();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Makes { get; private set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadDDL();
                return Page();
            }


            CarModel.CreatedBy = "Sajesh";
            CarModel.CreatedDate = DateTime.Now;

            _context.CarModels.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
        }
    }

}
