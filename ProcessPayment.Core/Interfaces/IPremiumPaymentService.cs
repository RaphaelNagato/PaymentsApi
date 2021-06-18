using ProcessPayment.Models;

namespace ProcessPayment.Core.Interfaces
{
    public interface IPremiumPaymentService
    {
        Payment ProcessPayment(Payment payment);
    }
}
