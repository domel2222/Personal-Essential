namespace Infrastructure.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PersonalDbContext _dbContext;

        public UnitOfWork(PersonalDbContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
                _dbContext.SaveChangesAsync(cancellationToken);

    }
}
