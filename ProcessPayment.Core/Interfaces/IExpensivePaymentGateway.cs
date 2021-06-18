using ProcessPayment.Models;

namespace ProcessPayment.Core.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Payment ProcessPayment(Payment payment);
        bool Available {get;}
    }
}
