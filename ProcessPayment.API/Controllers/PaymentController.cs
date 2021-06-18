using Microsoft.AspNetCore.Mvc;
using ProcessPayment.Commons;
using ProcessPayment.Dto;
using ProcessPayment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProcessPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("process-payment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDetailsDto paymentDetails)
        {
            List<KeyValue> listOfErrors = await Helper.ValidatePaymentDetails(paymentDetails);
            Response result = new Response();

            if (listOfErrors.Count != 0)
            {
                result.Message = "request is invalid";
                result.Errors = listOfErrors;
                return BadRequest(result);
            }

            result.Message = "request is successful";
            return Ok(result);

        }
    }
}
