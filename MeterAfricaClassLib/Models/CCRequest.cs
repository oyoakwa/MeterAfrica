using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class CCRequest
    {
        public string Email { get; set; } = "akwamailing@gmail.com";
            
        public string Amount { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string cardCvv { get; set; }

        [Required]
        public string cardExpiryMonth { get; set; }

        [Required]
        public string cardExpiryYear { get; set; }

        [Required]
        public string pin { get; set; }

    }
}
