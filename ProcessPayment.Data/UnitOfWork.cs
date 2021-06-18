using ProcessPayment.Models;
using System.Threading.Tasks;

namespace ProcessPayment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        private GenericRepository<Payment> _paymentRepository;
        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> Complete()
        {
            return await _ctx.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public GenericRepository<Payment> PaymentRepository
        {
            get
            {
                if(_paymentRepository == null)
                {
                    _paymentRepository = new GenericRepository<Payment>(_ctx);
                }
                return _paymentRepository;
            }
        }
  
    }
}
