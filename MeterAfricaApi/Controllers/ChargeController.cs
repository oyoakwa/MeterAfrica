using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterAfricaClassLib.Models;
using MeterAfricaClassLib.Services.MeterAfricaServices;
using MeterAfricaClassLib.Services.PayStackService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MeterAfricaApi.Controllers
{
    [Route("api/charge")]
    [ApiController]
    public class ChargeController : ControllerBase
    {

        private readonly IGetDiscoService _discoService;
        private readonly IValidateMeterNumberService _validateMeter;
        private readonly IConfiguration _configuration;
        private readonly PayServices _pay;
        public ChargeController(IGetDiscoService discoService, IValidateMeterNumberService validateMeter, PayServices pay)
        {
            _discoService = discoService
                ?? throw new ArgumentNullException(nameof(discoService));
            _validateMeter = validateMeter
                ?? throw new ArgumentNullException(nameof(validateMeter));
            _pay = pay
                ?? throw new ArgumentNullException(nameof(pay));
        }

        [HttpPost("charge/card")]
        public async Task<ActionResult<CCResponse>> ProcessCharge(CCRequest request, string otp = null)
        {
            var response = await _pay.ChargeCard(request);
            if (!response.status)
            {
                return Ok(response);
            }
            else
            {
                return null;
            }
        }

        [HttpPost("charge/{otp}")]
        public async Task<ActionResult<CCResponse>> ProcessCharge(OtpRequest req)
        {
            var response = await _pay.SendOtp(req.refe, req.Otp);
            return response;
        }
    }
}
