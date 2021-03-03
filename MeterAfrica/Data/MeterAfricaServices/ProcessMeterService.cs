using MeterAfricaClassLib.Models;
using MeterAfricaClassLib.Services;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using MeterAfricaClassLib.Services.PayStackService;
using MeterAfricaClassLib.Utilities;
using MeterAfricaClassLibrary.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeterAfrica.Data.MeterAfricaServices
{
    public class ProcessMeterService
    {
        private readonly IConfiguration _configuration;
        private readonly IResponseService _responseService;
        private readonly IBaseHttpClient _http;
        public ProcessMeterService(IResponseService responseService, IBaseHttpClient http, IConfiguration config)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _responseService = responseService
                ?? throw new ArgumentNullException(nameof(responseService));
            _configuration = config
                ?? throw new ArgumentNullException(nameof(config));
        }

        public DiscoResponse GetDiscos() 
        {
            try
            {
                GetDiscoService gds = new GetDiscoService(_responseService,_http); 
                var response = gds.GetDiscos().Result.Data; //_http.GetAsync<DiscoResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, url: "/api/processtoken/get-discos").Result;

                if (response.status)
                {
                    return response;
                }
                else
                {
                    return null;
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        public async Task<ServiceResponseModel<ValidateMeterResponseRoot>> ValidateMeter(MeterValidateReq req)
        {
            try
            {
                // var response = await _http.PostAsync<ValidateMeterResponseRoot>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: "/api/processtoken/validate-meter");
                ValidateMeterNumberService vms = new ValidateMeterNumberService(_responseService, _http);
                var response = vms.ValidateMeterNo(req).Result;
                if (response.Status)
                {
                    return _responseService.SuccessResponse<ValidateMeterResponseRoot>("Yes! Meter is valid", response.Data);
                }
                else
                {
                    return _responseService.ErroResponse<ValidateMeterResponseRoot>("Mater is invalid");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<ServiceResponseModel<CCResponse>> ChargeUserCard(CCRequest req)
        {
            try
            {
                //var response = await _http.PostAsync<CCResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: "/api/charge/charge/card");
                PayServices ps = new PayServices(_configuration,_http, _responseService);
                var response = ps.ChargeCard(req).Result;
                if (response.status)
                {
                    return _responseService.SuccessResponse<CCResponse>("Success! card Charged", response);
                }
                else
                {
                    return _responseService.ErroResponse<CCResponse>("Unabe to charge card");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ServiceResponseModel<CCResponse>> ChargeWithOtp(OtpRequest req)
        {
            try
            {
                //var response = await _http.PostAsync<CCResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: $"/api/charge/charge/{req.Otp}");

                PayServices ps = new PayServices(_configuration,_http, _responseService);
                var response = ps.SendOtp(req.refe, req.Otp).Result;
                if (response.status)
                {
                    return _responseService.SuccessResponse<CCResponse>("Success! card Charged", response);
                }
                else
                {
                    return _responseService.ErroResponse<CCResponse>("Unabe to charge card");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ServiceResponseModel<PaystackResponse>> VerifyPay(string payRef)
        {
            var reqObj = new
            {
                PaymentReference = payRef
            };
            PayServices ps = new PayServices(_configuration, _http, _responseService);
            var verifyTransactionRequest = ps.MakePaystackRequest($"{PaystackApiEndPoints.VerifyTransaction}/{reqObj.PaymentReference}",
                  HttpMethod.Get, null);
            var verifyResponse =
                   JsonConvert.DeserializeObject<PaystackResponse>(verifyTransactionRequest);

            if (verifyResponse.Status)
            {
                return _responseService.SuccessResponse<PaystackResponse>("Payment Made!", verifyResponse);
            }
            else
            {
                return _responseService.ErroResponse<PaystackResponse>("Unabe to charge card");
            }
        }

        public async Task<ServiceResponseModel<TokenResponse>> GetToken(string transReference, decimal amount)
        {
            GetTokenService gts = new GetTokenService(_http, _responseService);
            var response = gts.GetToken(transReference, amount).Result;
            if (response.Data.status)
            {
                return _responseService.SuccessResponse<TokenResponse>("Token Retrived", response.Data);
            }
            else
            {
                return _responseService.ErroResponse<TokenResponse>("Mater is invalid");
            }
        }
    }
}

