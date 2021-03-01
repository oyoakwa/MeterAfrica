using System;
using System.Collections.Generic;
using System.Text;

public class ServiceSetting
{
    public int id { get; set; }
    public string title { get; set; }
    public string code { get; set; }
    public string type { get; set; }
    public string mode { get; set; }
    public string enable { get; set; }
}

public class Datum
{
    public string reference { get; set; }
    public string name { get; set; }
    public string maxPurchase { get; set; }
    public string minPurchase { get; set; }
}

public class DiscoResponse
{
    public string message { get; set; }
    public bool status { get; set; }
    public List<Datum> data { get; set; }
}
