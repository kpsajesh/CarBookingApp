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
    public class IndexModel : PageModel
    {
        /* //Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Make> _repository;
        public IndexModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }

        public IList<Make> Makes { get;set; }

        public async Task OnGetAsync()
        {
            /*//Before Adding Repository
            Make = await _context.Makes.ToListAsync();*/
            Makes = await _repository.GetAll();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            await _repository.Delete(RecordId.Value);
            /*//Before Adding Repository
            var Make = await _context.Makes.FindAsync(RecordId);

            if (Make != null)
            {
                _context.Makes.Remove(Make);
                await _context.SaveChangesAsync();
            }*/

            return RedirectToPage("./Index");
        }
    }
}
