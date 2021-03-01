using System;
using System.Collections.Generic;
using System.Text;

public class Data
{
    public string fullName { get; set; }
    public string meterRef { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string email { get; set; }
    public string maxPurchaseAmount { get; set; }
    public string minPurchaseAmount { get; set; }
    public string discoName { get; set; }
    public string discoRef { get; set; }
    public string transactionRef { get; set; }
}

public class ValidateMeterResponseRoot
{
    public string message { get; set; }
    public bool status { get; set; }
    public string amount { get; set; }
    public Data data { get; set; }
}
