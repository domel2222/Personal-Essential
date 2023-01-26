namespace Domain.Repositories
{
    public interface IBaseAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(T entity);

        void Remove(T entity);
    }
}