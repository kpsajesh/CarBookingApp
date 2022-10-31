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

namespace CarBookingApp.Pages.Styles
{
    public class DetailsModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Style> _repository;
        public DetailsModel(IGenericRepository<Style> repository)
        {
            this._repository = repository;
        }

        public Style Style { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*//Before Adding Repository
            Style = await _context.Style.FirstOrDefaultAsync(m => m.Id == id);*/
            Style = await _repository.Get(id.Value);

            if (Style == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
