using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class PaymentNotificationModel
    {
        public string PaymentReference { get; set; }
        public string Amount { get; set; }
        public string MeterNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }
    }
}
