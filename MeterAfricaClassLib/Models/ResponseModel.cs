using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

public class Pagination<T>
{
    public IList<T> ReturnedList { get; set; }
    public int TotalCount { get; set; }
    public string Summary { get; set; }
    public int CurrentPage { get; set; }
    public long PageCount { get; set; }
}


public class ServiceResponseModel<T>
{
    public string Message { get; set; }
    public bool Status { get; set; }
    public T Data { get; set; }
}

public class ExternalResponseModel<T>
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; }
}
