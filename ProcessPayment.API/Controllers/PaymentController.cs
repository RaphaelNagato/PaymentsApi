using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessPayment.Commons;
using ProcessPayment.Core.Interfaces;
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
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

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

            Payment incomingPayment = _mapper.Map<PaymentDetailsDto, Payment>(paymentDetails);
            var result = await _paymentService.AddPayment(incomingPayment);
            if(result)
            {
                return Ok(new ApiResponse(200));
            }
            return BadRequest(new ApiResponse(502, "Request could not be processed"));

        }
    }
}
