using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken = default);

        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(User user);

        void Remove(User user);
    }
}