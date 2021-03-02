using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterAfricaClassLib.Models;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using MeterAfricaClassLib.Services.PayStackService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MeterAfricaApi.Controllers
{
    [Route("api/processtoken")]
    [ApiController]
    public class ProcessTokenController : ControllerBase
    {
        private readonly IGetDiscoService _discoService;
        private readonly IValidateMeterNumberService _validateMeter;
        private readonly IConfiguration _configuration;
        

        public ProcessTokenController(IGetDiscoService discoService, IValidateMeterNumberService validateMeter, PayServices pay)
        {
            _discoService = discoService
                ?? throw new ArgumentNullException(nameof(discoService));
            _validateMeter = validateMeter
                ?? throw new ArgumentNullException(nameof(validateMeter));
        }
        
        [HttpGet("get-discos")]
        public async Task<ActionResult<DiscoResponse>> GetDisco()
        {
            try
            {
                var res = await _discoService.GetDiscos();
                var responseData = res.Data;
                return Ok(responseData);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
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
