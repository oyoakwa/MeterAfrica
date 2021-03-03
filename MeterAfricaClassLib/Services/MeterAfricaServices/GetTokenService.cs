using MeterAfricaClassLib.Models;
using MeterAfricaClassLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLib.Services.MeterAfricaServices
{
    public class GetTokenService
    {
        private readonly IBaseHttpClient _http;
        private readonly IResponseService _responseService;
        public GetTokenService(IBaseHttpClient http, IResponseService responseService)
        {
            _http = http
                ?? throw new ArgumentNullException(nameof(http));
            _responseService = responseService
            ?? throw new ArgumentNullException(nameof(responseService));
        }

        public async Task<ServiceResponseModel<TokenResponse>> GetToken(string transReference, decimal amount)
        {
            try
            {
                var reqObj = new
                {
                    transactionRef = transReference,
                    amount = amount
                };

                var response = await _http.PostAsync<TokenResponse>(baseUrl: StaticAppSettings.MeterNgBaseUrl, postdata: reqObj, url: "/Sales/purchase-power");
                if (response.status)
                {
                    return _responseService.SuccessResponse<TokenResponse>("Token Generated", response);
                }
                else
                {
                    return _responseService.ErroResponse<TokenResponse>("Unable To Generate Token");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
