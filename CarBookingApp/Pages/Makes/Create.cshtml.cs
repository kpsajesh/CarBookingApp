using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Makes
{
    public class CreateModel : PageModel
    {
        

        /* Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Make> _repository;
        public CreateModel(IGenericRepository<Make> repository)
        {            
            this._repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Make Make { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        
        /*Before Adding Repository
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Make.CreatedBy = "Sajesh";
            Make.CreatedDate = DateTime.Now;

            _context.Makes.Add(Make);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Make.CreatedBy = "Sajesh";
            //Make.CreatedDate = DateTime.Now;

            await _repository.Insert(Make);

            return RedirectToPage("./Index");
        }
    }
}
