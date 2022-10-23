using CareBookingAppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public class Make
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Make")]
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }

    }
}
