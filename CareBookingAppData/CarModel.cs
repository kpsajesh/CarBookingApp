using CarBookingAppData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareBookingAppData
{
    public class CarModel:BaseDomainEntity
    {
        [Required]
        [Display(Name = "Car Model")]
        public string Name { get; set; }

        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}