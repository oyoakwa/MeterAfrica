using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class TokenData
    {
        public string reference { get; set; }
        public string units { get; set; }
        public decimal amount { get; set; }
        public string address { get; set; }
        public string meterToken { get; set; }
    }

    public class TokenResponse
    {
        public string message { get; set; }
        public bool status { get; set; }
        public TokenData data { get; set; }
    }
}
