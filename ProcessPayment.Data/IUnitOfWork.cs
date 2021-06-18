using ProcessPayment.Models;
using System;
using System.Threading.Tasks;

namespace ProcessPayment.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
        GenericRepository<Payment> PaymentRepository {get;}
    }
}
