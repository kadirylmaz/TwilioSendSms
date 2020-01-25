using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSms.Models;
using SendSms.Services;
using SendSms.Validator;

namespace SendSms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ISmsService _smsService;
        public MessagesController(ISmsService smsService)
        {
            this._smsService = smsService;
        }

        [HttpPost("send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Send([FromBody] SmsMessage model)
        {
            var errors = ValidationService.Validate(out bool isValid, model);
            if (isValid)
            {
                var result = await _smsService.Send(model);

                return Ok(new GenericApiResponse(result));
            }
            else
            {
                return BadRequest(new GenericApiResponse(errors));
            }
        }
    }
}