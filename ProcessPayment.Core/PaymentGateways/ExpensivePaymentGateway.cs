using ProcessPayment.Core.Interfaces;
using ProcessPayment.Models;

namespace ProcessPayment.Core.PaymentGateways
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool Available { get; } = true;

        public Payment ProcessPayment(Payment payment)
        {
            //set of rules can be defined to set payment status

            payment.Status = PaymentState.Processed; // set payment status to processed by default
            return payment;
        }
    }
}
