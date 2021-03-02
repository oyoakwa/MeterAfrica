using MeterAfricaClassLib.Models;
using MeterAfricaClassLib.Services;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using MeterAfricaClassLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterAfrica.Data.MeterAfricaServices
{
    public class ProcessMeterService
    {
        private readonly IResponseService _responseService;
        private readonly IBaseHttpClient _http;
        public ProcessMeterService(IResponseService responseService, IBaseHttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _responseService = responseService
                ?? throw new ArgumentNullException(nameof(responseService));
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
                var response = vms.ValidateMeterNo(req).Result.Data;
                if (response.status)
                {
                    return _responseService.SuccessResponse<ValidateMeterResponseRoot>("Yes! Meter is valid", response);
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
                var response = await _http.PostAsync<CCResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: "/api/charge/charge/card");

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
                var response = await _http.PostAsync<CCResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: $"/api/charge/charge/{req.Otp}");

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
    }
}

