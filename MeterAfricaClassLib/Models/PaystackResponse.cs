using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class PaystackResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
