using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly PersonalDbContext _personalDbContext;

        public UserRepository(PersonalDbContext personalDbContext) => _personalDbContext = personalDbContext;

        public bool CheckEmail(string email)
        {
            return _personalDbContext.Users.Any(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllActiveUserAsync(CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Users.Where(x => x.InactivatedDate == null).ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id && x.InactivatedDate == null, cancellationToken);
        }

        public void Insert(User? user)
        {
            if (user != null)
            {
                _personalDbContext.Users.Add(user);
            }
        }

        public void Remove(User user)
        {
            _personalDbContext.Users.Remove(user);
        }

    }
}