using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseAsyncRepository<T> where T : AuditableEntity
    {
        protected readonly PersonalDbContext _personalDbContext;

        public BaseRepository(PersonalDbContext personalDbContext) => _personalDbContext = personalDbContext;

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Set<T>()
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id && x.InactivatedDate == null, cancellationToken);
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                _personalDbContext.Set<T>().Add(entity);
            }
        }

        public void Remove(T entity)
        {
            _personalDbContext.Set<T>().Remove(entity);
        }
    }
}