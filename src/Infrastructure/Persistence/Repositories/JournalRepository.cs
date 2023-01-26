namespace Infrastructure.Persistence.Repositories
{
    public sealed class JournalRepository : BaseRepository<Journal>, IJournalRepository
    {
        public JournalRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }

        public async Task<IReadOnlyCollection<Journal>> GetAllJournalsByUserId(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _personalDbContext.Journals
                                                .AsNoTracking()
                                                .Where(user => user.UserId == userId
                                                 && user.InactivatedDate == null)
                                                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<Journal>> GetJournalByUserIdAndDateAsync(Guid userId, DateTime diaryDate, CancellationToken cancellationToken)
        {
            return await _personalDbContext.Journals
                                                .AsNoTracking()
                                                .Where(x => x.UserId == userId
                                                && x.DiaryDate >= diaryDate && x.DiaryDate < diaryDate.AddDays(1)
                                                && x.InactivatedDate == null)
                                                .ToListAsync(cancellationToken);
        }

    }
}