using ProcessPayment.Commons.Validators;
using ProcessPayment.Dto;
using ProcessPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static async Task<List<KeyValue>> ValidatePaymentDetails(PaymentDetailsDto paymentDetails)
        {
            List<KeyValue> validationErrors = new List<KeyValue>();
            var validator = new PaymentDetailsValidator();
            var results = await validator.ValidateAsync(paymentDetails);
            if(!results.IsValid)
            {
                validationErrors.AddRange(results.Errors.Select(error => new KeyValue
                { 
                    PropertyName = error.PropertyName,
                    PropertyValue = error.ErrorMessage,
                }));
            }
            return validationErrors;
        }
    }
}
