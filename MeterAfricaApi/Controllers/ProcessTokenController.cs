using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using Microsoft.AspNetCore.Mvc;

namespace MeterAfricaApi.Controllers
{
    [Route("api/processtoken")]
    [ApiController]
    public class ProcessTokenController : ControllerBase
    {
        private readonly IGetDiscoService _discoService;
        private readonly IValidateMeterNumberService _validateMeter;
        
        public ProcessTokenController(IGetDiscoService discoService, IValidateMeterNumberService validateMeter)
        {
            _discoService = discoService
                ?? throw new ArgumentNullException(nameof(discoService));
            _validateMeter = validateMeter
                ?? throw new ArgumentNullException(nameof(validateMeter));
        }
        
        [HttpGet("get-discos")]
        [ProducesResponseType(type: typeof(ServiceResponseModel<DiscoResponse>), statusCode: 200)]
        public async Task<IActionResult> GetDisco()
        {
            var res = await _discoService.GetDiscos();
            return Ok(res);
        }

        [HttpPost("Validate-meter")]
        [ProducesResponseType(type: typeof(ServiceResponseModel<ValidateMeterResponseRoot>), statusCode: 200)]
        public async Task<IActionResult> ValidateMeter(MeterValidateReq req)
        {
            var response = await _validateMeter.ValidateMeterNo(req);
            return Ok(response);
        }
    }
}
