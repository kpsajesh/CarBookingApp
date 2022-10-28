using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareBookingAppData;

namespace CarBookingApp.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public EditModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
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

            Cars = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            

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
            if (!ModelState.IsValid)
            {
                /*Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
                Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");*/
                await LoadDDL();
                return Page();
            }

            Cars.UpdatedBy = "Sajesh";
            Cars.UpdatedDate = DateTime.Now;

            _context.Attach(Cars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Cars.Id))
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

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
        private async Task LoadDDL()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Styles = new SelectList(await _context.Styles.ToListAsync(), "Id", "Name");
            /*CarModels = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");*/
        }
        public async Task<JsonResult> OnGetCarModels(int PKtoPass)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == PKtoPass)
                .ToListAsync();

            return new JsonResult(models);
        }
    }
}
