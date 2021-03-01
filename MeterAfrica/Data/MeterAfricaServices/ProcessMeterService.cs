using MeterAfricaClassLib.Services;
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

        public async Task<ServiceResponseModel<DiscoResponse>> GetDiscos()
        {
            try
            {
                var response = await _http.GetAsync<DiscoResponse>(baseUrl: StaticAppSettings.MeterNgBaseUrl, url: "/api/processtoken/get-discos");

                if (response.status)
                    return _responseService.SuccessResponse<DiscoResponse>("Discos Retrived Sucessfully", response);
                else
                    return _responseService.ErroResponse<DiscoResponse>("Discos Retrival Fail");
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<ServiceResponseModel<ValidateMeterResponseRoot>> ValidateMeter(MeterValidateReq req)
        {
            try
            {
                var response = await _http.PostAsync<ValidateMeterResponseRoot>(baseUrl: StaticAppSettings.MeterNgBaseUrl, postdata: req, url: "/api/processtoken/validate-meter");
                if (response.status)
                {
                    return _responseService.SuccessResponse<ValidateMeterResponseRoot>("Yes! Meter is valid", response);
                }
                else
                {
                    return _responseService.ErroResponse<ValidateMeterResponseRoot>("Mater is invalid");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

