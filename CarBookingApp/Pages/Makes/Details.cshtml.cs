using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CareBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Makes
{
    public class DetailsModel : PageModel
    {
        /*//efore Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Make> _repository;
        public DetailsModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }      

        public Make Makes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            Make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);*/

            Makes = await _repository.Get(id.Value);

            if (Makes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
