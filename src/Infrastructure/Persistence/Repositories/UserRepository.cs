using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }

        public bool CheckEmail(string email)
        {
            return _personalDbContext.Users
                                        .AsNoTracking()
                                        .Any(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllActiveUserAsync(CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Users
                                        .AsNoTracking()
                                        .Where(x => x.InactivatedDate == null).ToListAsync(cancellationToken);
        }
    }
}