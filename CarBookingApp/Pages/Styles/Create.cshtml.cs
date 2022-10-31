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

namespace CarBookingApp.Pages.Styles
{
    public class CreateModel : PageModel
    {


        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Style> _repository;
        public CreateModel(IGenericRepository<Style> repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Style Style { get; set; }
        public IGenericRepository<Style> Repository { get; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*//Before Adding Repository
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Style.CreatedBy = "Sajesh";
            Style.CreatedDate = DateTime.Now;

            _context.Styles.Add(Style);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Style.CreatedBy = "Sajesh";
            //Style.CreatedDate = DateTime.Now;

            await _repository.Insert(Style);

            return RedirectToPage("./Index");
        }
    }
}
