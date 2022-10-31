using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Styles
{
    public class EditModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Style> _repository;
        public EditModel(IGenericRepository<Style> repository)
        {
            this._repository = repository;
        }

        [BindProperty]
        public Style Style { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            Style = await _context.Styles.FirstOrDefaultAsync(m => m.Id == id);*/
            Style = await _repository.Get(id.Value);

            if (Style == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Style.UpdatedBy = "Sajesh";
            Style.CreatedBy = "Sajesh";
            //Style.UpdatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.Attach(Style).State = EntityState.Modified;
            //No codes added here*/
            

            try
            {
                /*//Before Adding Repository
                await _context.SaveChangesAsync();*/
                await _repository.Update(Style);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*//Before Adding Repository
                if (!StyleExists(Style.Id))*/ // Made to async
                if (! await StyleExistsAsync(Style.Id))
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
        private bool StyleExists(int id)// made to Asnyc
        {
            return _context.Styles.Any(e => e.Id == id);
        }*/
        private async Task<bool> StyleExistsAsync(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
