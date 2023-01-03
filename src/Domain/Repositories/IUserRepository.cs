using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IBaseAsyncRepository<User>
    {
        bool CheckEmail(string email);

        Task<IEnumerable<User>> GetAllActiveUserAsync(CancellationToken cancellationToken = default);
    }
}