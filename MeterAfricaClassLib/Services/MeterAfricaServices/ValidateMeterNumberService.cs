using MeterAfricaClassLib.Services;
using MeterAfricaClassLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public interface IValidateMeterNumberService
{
    Task<ServiceResponseModel<ValidateMeterResponseRoot>> ValidateMeterNo(MeterValidateReq req);
}

public class ValidateMeterNumberService : IValidateMeterNumberService
{
    private readonly IResponseService _responseService;
    private readonly IBaseHttpClient _http;

    public ValidateMeterNumberService(IResponseService responseService, IBaseHttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        _responseService = responseService
            ?? throw new ArgumentNullException(nameof(responseService));
    }

    public async Task<ServiceResponseModel<ValidateMeterResponseRoot>> ValidateMeterNo(MeterValidateReq req)
    {
        try
        {
            var response = await _http.PostAsync<ValidateMeterResponseRoot>(baseUrl: StaticAppSettings.MeterNgBaseUrl, postdata: req, url: "/Sales/validate-meter");
            if (response.status)
            {
                return _responseService.SuccessResponse<ValidateMeterResponseRoot>("Meter is valid", response);
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
