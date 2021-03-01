using MeterAfricaClassLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLib.Services.MeterAfricaServices
{
    public interface IGetDiscoService
    {
        Task<ServiceResponseModel<DiscoResponse>> GetDiscos();
    }

    public class GetDiscoService : IGetDiscoService
    {
        private readonly IResponseService _responseService;
        private readonly IBaseHttpClient _http;

        public GetDiscoService(IResponseService responseService, IBaseHttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _responseService = responseService
                ?? throw new ArgumentNullException(nameof(responseService));
        }

        public async Task<ServiceResponseModel<DiscoResponse>> GetDiscos()
        {
            try
            {
                var response = await _http.GetAsync<DiscoResponse>(baseUrl: StaticAppSettings.MeterNgBaseUrl, url: "/Sales/get-disco");
                if (!response.status)
                {
                    return _responseService.ErroResponse<DiscoResponse>("Hello Merchant, get this issue sorted out by calling 07067508940");
                }
                else
                {
                    return _responseService.SuccessResponse<DiscoResponse>("Discos retrived sucessfully", response);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
