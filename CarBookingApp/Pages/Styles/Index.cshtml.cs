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
    public class IndexModel : PageModel
    {
        /*//Before Adding Repository
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CareBookingAppData.CarBookingAppDbContext context)
        {
        _context = context;
        }*/

        private readonly IGenericRepository<Style> _repository;
        public IndexModel(IGenericRepository<Style> repository)
        {
            this._repository = repository;
        }
        

        public IList<Style> Styles { get;set; }

        public async Task OnGetAsync()
        {
            /*//Before Adding Repository
            Styles = await _context.Styles.ToListAsync();*/
            Styles = await _repository.GetAll();
        }
        public async Task<IActionResult> OnPostDelete5Async(int? RecordId)
        {
            if (RecordId == null)
            {
                return NotFound();
            }

            await _repository.Delete(RecordId.Value);

            /*//Before Adding Repository
            var Style = await _context.Styles.FindAsync(RecordId);

            if (Style != null)
            {
                _context.Styles.Remove(Style);
                await _context.SaveChangesAsync();
            }*/

            return RedirectToPage("./Index");
        }
    }
}
