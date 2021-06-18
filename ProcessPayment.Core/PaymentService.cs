using ProcessPayment.Core.Interfaces;
using ProcessPayment.Data;
using ProcessPayment.Models;
using System.Threading.Tasks;

namespace ProcessPayment.Core
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentService _premiumPaymentService;

        public PaymentService(IUnitOfWork unitOfWork, ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentService premiumPaymentService)
        {
            _unitOfWork = unitOfWork;
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentService = premiumPaymentService;
        }


        public async Task<bool> AddPayment(Payment payment)
        {
            Payment processedPayment = payment;
            processedPayment.Status = PaymentState.Pending;

            if (payment.Amount < 20)
            {
                processedPayment = ProcessWithCheapGateway(payment);
            }
            else if (payment.Amount >= 21 && payment.Amount <= 500)
            {
                // process with IExpensivePaymentGateway if available
                if (_expensivePaymentGateway.Available)
                {
                    processedPayment = ProcessWithExpensiveGateway(payment);
                }
                else
                {
                    processedPayment = ProcessWithCheapGateway(payment);
                }
                

            }
            else if (payment.Amount > 500)
            {
                processedPayment = ProcessWithPremiumService(payment);
            }

            if (processedPayment.Status != PaymentState.Processed)
            {
                return false;
            }
            return await _unitOfWork.Complete() > 0;
        }

        private Payment ProcessWithExpensiveGateway(Payment payment)
        {
            Payment processedPayment = _expensivePaymentGateway.ProcessPayment(payment);
            _unitOfWork.PaymentRepository.Add(processedPayment);
            return processedPayment;
        }

        private Payment ProcessWithPremiumService(Payment payment)
        {
            Payment processedPayment;
            var count = 0;
            do
            {
                processedPayment = _premiumPaymentService.ProcessPayment(payment);
                if (processedPayment.Status == PaymentState.Processed)
                {
                    break;
                }
                count++;

            } while (count < 3);
            _unitOfWork.PaymentRepository.Add(processedPayment);
            return processedPayment;
        }

        private Payment ProcessWithCheapGateway(Payment payment)
        {
            //process with ICheapPaymentGateway
            Payment processedPayment = _cheapPaymentGateway.ProcessPayment(payment);
            //add to context
            _unitOfWork.PaymentRepository.Add(processedPayment);
            return processedPayment;
        }
    }
}
