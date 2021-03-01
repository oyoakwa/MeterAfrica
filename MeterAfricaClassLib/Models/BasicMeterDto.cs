using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class BasicMeterDto
    {
        [Display(Name = "Merchant")]
        [Required]
        public string Merchant { get; set; }

        public MeterValidateReq MeterValidateReq { get; set; }
    }
}

