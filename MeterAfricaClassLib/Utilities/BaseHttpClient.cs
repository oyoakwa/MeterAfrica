using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLibrary.Utilities
{

    public interface IBaseHttpClient
    {
        Task<string> PostAsync(string baseUrl, object postdata, string url, string token = null, string apikey = null);
        Task<T> PostAsync<T>(string baseUrl, object postdata, string url, string token = null, string apikey = null);
        Task<T> GetAsync<T>(string baseUrl, string url, string token = null, string apikey = null);
    }
    public class BaseHttpClient : IBaseHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BaseHttpClient> _logger;
        public BaseHttpClient(IHttpClientFactory httpClientFactory, ILogger<BaseHttpClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public virtual async Task<T> GetAsync<T>(string baseUrl, string url, string token = null, string apikey = null)
        {
            T returnValue;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Merchant-Key", StaticAppSettings.MerchantKey);
            if (!string.IsNullOrEmpty(apikey))
                client.DefaultRequestHeaders.Add("api-key", apikey);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var _url = $"{baseUrl}{url}";
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            using var httpResponse =  client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
           // _logger.LogCritical(Utilities.SerializeToJson(httpResponse));
            returnValue = await Utilities.DeserializeRequestAsync<T>(httpResponse);

            return returnValue;

        }

        public async Task<T> PostAsync<T>(string baseUrl, object postdata, string url, string token = null, string apikey = null)
        {
            T returnValue;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Merchant-Key", StaticAppSettings.MerchantKey);
            if (!string.IsNullOrEmpty(apikey))
                client.DefaultRequestHeaders.Add("api-key", apikey);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var _url = $"{baseUrl}{url}";
            var request = new HttpRequestMessage(HttpMethod.Post, _url);
            var jsonContent = Utilities.SerializeToJson(postdata);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using var httpResponse = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;

            returnValue = await Utilities.DeserializeRequestAsync<T>(httpResponse);
            return returnValue;
        }

        public async Task<string> PostAsync(string baseUrl, object postdata, string url, string token = null, string apikey = null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Merchant-Key", StaticAppSettings.MerchantKey);
            if (!string.IsNullOrEmpty(apikey))
                client.DefaultRequestHeaders.Add("api-key", apikey);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var _url = $"{baseUrl}{url}";
            var request = new HttpRequestMessage(HttpMethod.Post, _url);
            var jsonContent = Utilities.SerializeToJson(postdata);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            request.Content = stringContent;
            using var httpResponse = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var returnValue = await Utilities.DeserializeRequestAsync<string>(httpResponse);
            return returnValue;
        }
    }
}
