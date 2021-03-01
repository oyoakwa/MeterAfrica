using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeterAfrica.Data
{
    public class BasicMeterDto
    {
        //[Display(Name = "Merchant")]
        //[Required]
        //public string Merchant { get; set; }

        public MeterValidateReq MeterValidateReq { get; set; }
    }
}
