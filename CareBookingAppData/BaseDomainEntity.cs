﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public string CreatedBy{ get; set; }
        public string UpdatedBy{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime UpdatedDate{ get; set; }


    }
}
