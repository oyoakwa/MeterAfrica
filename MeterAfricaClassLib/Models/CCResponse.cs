using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Models
{
    public class Metadata
    {
        public List<object> custom_fields { get; set; }
    }

    public class Authorization
    {
        public string authorization_code { get; set; }
        public string bin { get; set; }
        public string last4 { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string channel { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public string country_code { get; set; }
        public string brand { get; set; }
        public bool reusable { get; set; }
        public string signature { get; set; }
    }

    public class Customer
    {
        public int id { get; set; }
        public string email { get; set; }
        public string customer_code { get; set; }
        public string risk_action { get; set; }
    }

    public class Data
    {
        public decimal amount { get; set; }
        public string currency { get; set; }
        public DateTime transaction_date { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public string domain { get; set; }
        public Metadata metadata { get; set; }
        public string gateway_response { get; set; }
        public string channel { get; set; }
        public string ip_address { get; set; }
        public int fees { get; set; }
        public Authorization authorization { get; set; }
        public Customer customer { get; set; }
        public decimal? RealAmount { get; set; }
    }

    public class CCResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
