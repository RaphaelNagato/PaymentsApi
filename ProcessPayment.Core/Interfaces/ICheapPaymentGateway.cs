using ProcessPayment.Models;

namespace ProcessPayment.Core.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Payment ProcessPayment(Payment payment);
    }
}
