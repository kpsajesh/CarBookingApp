﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareBookingAppData;

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

        public IActionResult OnGet()
        {
            Makes = new SelectList(_context.Makes.ToList(), "Id", "Name");
            Styles = new SelectList(_context.Styles.ToList(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
