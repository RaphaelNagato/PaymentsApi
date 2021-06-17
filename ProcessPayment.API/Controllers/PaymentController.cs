using Microsoft.AspNetCore.Mvc;
using ProcessPayment.Dto;


namespace ProcessPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("process-payment")]
        public IActionResult ProcessPayment([FromBody] PaymentDetailsDto paymentDetails)
        {
            return Ok();
        }
    }
}
