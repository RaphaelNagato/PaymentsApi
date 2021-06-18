using Microsoft.AspNetCore.Mvc;
using ProcessPayment.Commons;
using ProcessPayment.Dto;
using ProcessPayment.Models;
using ProcessPayment.Models.ResponseModels;
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
            List<string> listOfErrors = await Helper.ValidatePaymentDetails(paymentDetails);

            if (listOfErrors.Count != 0)
            {
                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = listOfErrors
                };
                return BadRequest(errorResponse);
            }

            var result = new ApiResponse(200);
            return Ok(result);

        }
    }
}
