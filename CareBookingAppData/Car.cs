using CarBookingAppData;
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

        [Required]
        [Range(1975,2075)]
        public int Year { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="Must be less than 15 chars.")]
        [Display(Name = "Model")]
        public string  Name  { get; set; }

        [Required]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        public int? StyleId { get; set; }
        public virtual Style Style { get; set; }
    }
}
