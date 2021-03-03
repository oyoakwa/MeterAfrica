using MeterAfricaClassLib.Models;
using MeterAfricaClassLib.Utilities;
using MeterAfricaClassLibrary.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLib.Services.PayStackService
{
    public class PayServices
    {
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        

        public PayServices(IConfiguration configuration, IBaseHttpClient http, IResponseService responseService)
        {
            _configuration = configuration;
            
        }

        public async Task<CCResponse> ChargeCard(CCRequest request)
        {
            var response = new CCResponse();
            try
            {
                PayStackApi _payApi = new PayStackApi(_configuration[Constants.PayStackKey]);

                decimal price = Convert.ToDecimal(request.Amount);
                decimal newAmount = (Convert.ToInt32(price) + 100) * 100;
                var req = new CardChargeRequest
                {
                    Amount = newAmount.ToString(),
                    Card = new Card
                    {
                        Number = request.CardNumber,
                        Cvv = request.cardCvv,
                        ExpiryMonth = request.cardExpiryMonth,
                        ExpiryYear = request.cardExpiryYear
                    },
                    Email = request.Email,
                    Reference = DateTime.Now.Ticks.ToString().Substring(0, 10),
                    Pin = request.pin
                };

                var payAesponse = _payApi.Charge.ChargeCard(req);

                if (!payAesponse.Status)
                {
                    throw new Exception(payAesponse?.Data?.Message);
                }
                var JsonObj = JsonConvert.SerializeObject(payAesponse);
                var resObj = JsonConvert.DeserializeObject<CCResponse>(JsonObj);// Variable to test if Serialized Object Holds Contents
                resObj.data.RealAmount = newAmount;
                response = resObj;


            }
            catch (Exception ec)
            {
                throw ec;

            }
            return await Task.FromResult(response);
        }

        public async Task<CCResponse> SendOtp(string refer, string otp)
        {
            CCResponse mainResponse;
            try
            {
                PayStackApi _payApi = new PayStackApi(_configuration[Constants.PayStackKey]);
                var response = _payApi.Charge.SubmitOTP(refer, otp);
                if (!response.Status)
                {
                    var x = response.Data.Message;
                }
                var JsonObj = JsonConvert.SerializeObject(response);
                var resObj = JsonConvert.DeserializeObject<CCResponse>(JsonObj);// Variable to test if Serialized Object Holds Contents
                mainResponse = resObj;

            }
            catch (Exception)
            {

                throw;
            }

            return await Task.FromResult(mainResponse);
        }

        public string MakePaystackRequest(string url, HttpMethod method, object model = null)
        {
            using (var client = new HttpClient())
            {
                var key = _configuration[Constants.PayStackKey];
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var postData = JsonConvert.SerializeObject(model);
                var request = new HttpRequestMessage(method, url)
                {
                    Content = new StringContent(model == null ? "" : JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };


                var getTask = client.SendAsync(request);
                getTask.Wait();

                var results = getTask.Result;
                if (results.IsSuccessStatusCode)
                {
                    var result = getTask.Result.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<PaystackResponse>(result);
                    if (!response.Status)
                    {
                        throw new Exception(response.Message);
                    }

                    return result;
                }
                else
                {
                    var result = getTask.Result.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<PaystackResponse>(result);
                    throw new Exception(response.Message);
                }
            }
        }

        
    }
}
