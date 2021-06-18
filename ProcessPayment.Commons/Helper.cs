using ProcessPayment.Commons.Validators;
using ProcessPayment.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPayment.Commons
{
    public static class Helper
    {
        /// <summary>
        /// Validate Incoming Payment Details using Fluent Api
        /// </summary>
        /// <param name="paymentDetails"></param>
        /// <returns></returns>
        public static async Task<List<string>> ValidatePaymentDetails(PaymentDetailsDto paymentDetails)
        {
            List<string> validationErrors = new List<string>();
            var validator = new PaymentDetailsValidator();
            var results = await validator.ValidateAsync(paymentDetails);
            if(!results.IsValid)
            {
                validationErrors.AddRange(results.Errors.Select(error => error.ErrorMessage).ToList());
            };
            return validationErrors;
        }
    }
}
