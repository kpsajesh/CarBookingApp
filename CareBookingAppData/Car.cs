using CarBookingAppData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareBookingAppData
{
    public class Car: BaseDomainEntity
    {
        //public int Id { get; set; } //commented as it is inherited from the BaseDomainEntity class

        //double intYear = double.Parse(DateTime.Now.Year.ToString());

        [Required]
        [Range(1975, 2075)]
        /*[Range(1975, 2075,ErrorMessage ="Year must be between 1975 & 2075")]*/ //Can add error message explicitely like this.
        public int Year { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="Must be less than 15 chars.")]
        [Display(Name = "Colour")]
        public string  Name  { get; set; }

        [Required]
        [Display(Name = "Make")]
        public int MakeId { get; set; }
        public virtual Make Make { get; set; }

        [Required]
        [Display(Name = "Style")]
        public int? StyleId { get; set; }
        public virtual Style Style { get; set; }

        [Display(Name = "Plate No")]
        public string RegnNo{ get; set; }

        [Required]
        [Display(Name = "Model")]
        public int? CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
    }
}
