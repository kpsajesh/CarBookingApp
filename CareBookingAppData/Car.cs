using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareBookingAppData
{
    public class Car
    {
        public int Id { get; set; }        
        public int Year { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="Must be less than 15 chars.")]
        public string Name  { get; set; }
    }
}
