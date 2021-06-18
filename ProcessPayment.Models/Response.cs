using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProcessPayment.Models
{
    public class Response
    {
        [DefaultValue(false)]
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<KeyValue> Errors { get; set; }
    }
}
