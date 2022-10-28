using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;

namespace CarBookingApp.Pages.CarModels
{
    public class EditModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public EditModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
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

            CarModel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);

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
            CarModel.UpdatedDate = DateTime.Now;
            _context.Attach(CarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(CarModel.Id))
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

        private bool CarModelExists(int id)
        {
            return _context.CarModels.Any(e => e.Id == id);
        }
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
        }
    }
}
