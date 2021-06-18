using System.Runtime.Serialization;

namespace ProcessPayment.Models
{
    public enum PaymentState
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Processed")]
        Processed,

        [EnumMember(Value = "Failed")]
        Failed
    }
}
