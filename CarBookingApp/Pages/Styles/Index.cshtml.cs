using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CareBookingAppData;

namespace CarBookingApp.Pages.Styles
{
    public class IndexModel : PageModel
    {
        private readonly CareBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CareBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Style> Style { get;set; }

        public async Task OnGetAsync()
        {
            Style = await _context.Styles.ToListAsync();
        }
    }
}
