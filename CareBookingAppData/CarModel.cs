using CarBookingAppData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareBookingAppData
{
    public class CarModel:BaseDomainEntity
    {
        [Required]
        [Display(Name = "Model")]
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}