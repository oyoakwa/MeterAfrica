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
                //GetDiscoService gds = new GetDiscoService(_responseService,_http); gds.GetDiscos().Result; //
                var response = _http.GetAsync<DiscoResponse>(baseUrl: StaticAppSettings.MeterAfBaseUrl, url: "/api/processtoken/get-discos").Result;


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
                var response = await _http.PostAsync<ValidateMeterResponseRoot>(baseUrl: StaticAppSettings.MeterAfBaseUrl, postdata: req, url: "/api/processtoken/validate-meter");
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
    }
}

