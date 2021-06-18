using ProcessPayment.Models;
using System.Threading.Tasks;

namespace ProcessPayment.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> AddPayment(Payment payment);
    }
}
