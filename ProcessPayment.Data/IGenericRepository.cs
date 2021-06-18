namespace ProcessPayment.Data
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
    }
}
