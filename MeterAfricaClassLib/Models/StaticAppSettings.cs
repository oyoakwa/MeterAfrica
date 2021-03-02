using System;
using System.Collections.Generic;
using System.Text;

public class StaticAppSettings
{
    public static string MeterAfBaseUrl { get; set; }
    public static string MeterNgBaseUrl { get; set; }
    public static string MerchantKey { get; set; }
}
public class AppSettings
{
    internal int EasyPayTopUp
    {
        get
        {
            return 100;
        }


    }

    public string ProviderMerchantCode { get; set; }
    public string MerchantCode { get; set; }
    public string MemmcolLiveEndPoint { get; set; }
    public string PaystackSecretKey { get; set; }
}
