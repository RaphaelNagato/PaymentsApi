namespace ProcessPayment.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly AppDbContext _ctx;

        public GenericRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }
    }
}
