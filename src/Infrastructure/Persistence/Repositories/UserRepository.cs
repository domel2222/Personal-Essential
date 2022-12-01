using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly PersonalDbContext _personalDbContext;

        public UserRepository(PersonalDbContext personalDbContext) => _personalDbContext = personalDbContext;

        public async Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Insert(User user)
        {
            _personalDbContext.Users.Add(user);
        }

        public void Remove(User user)
        {
            _personalDbContext.Users.Remove(user);
        }
        public void Update(User user) 
        { 

        }
    }
}