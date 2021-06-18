using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessPayment.Models.ResponseModels
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Request Successful",
                400 => "Bad Request ",
                401 => "Unauthorized",
                404 => "Resource not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }

        public int StatusCode { get; }
        public string Message { get; }


    }
}
