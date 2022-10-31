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

namespace CarBookingApp.Pages.Makes
{
    public class EditModel : PageModel
    {
        /*//Before Adding Repository
       private readonly CareBookingAppData.CarBookingAppDbContext _context;

       public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
       {
       _context = context;
       }*/

        private readonly IGenericRepository<Make> _repository;
        public EditModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }


        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _repository.Get(id.Value);

            if (Make == null)
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

            Make.UpdatedBy= "Sajesh";
            Make.CreatedBy = "Sajesh";
            //Make.UpdatedDate = DateTime.Now;

            /*//Before Adding Repository
            _context.Attach(Make).State = EntityState.Modified;
            //No codes added here*/

            try
            {
                await _repository.Update(Make);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*//Before Adding Repository
                if (!MakeExists(Make.Id))*/
                if (! await MakeExistsAsync(Make.Id))
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
        private bool MakeExists(int id)
        {
            return _context.Makes.Any(e => e.Id == id);
        }*/
        private async Task<bool> MakeExistsAsync(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
