using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CarBookingApp.Pages.Cars
{
    
    public class checkModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public checkModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string Message{ get; set; }
        public void OnGet()
        {
            Message = _configuration["Message"];
        }
    }
}
