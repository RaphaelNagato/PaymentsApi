using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessPayment.Models.ResponseModels
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
