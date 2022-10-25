using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using CareBookingAppData;

namespace CarBookingApp.Pages.Styles
{
    public class CreateModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Style Style { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
        }
    }
}
