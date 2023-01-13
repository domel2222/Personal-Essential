namespace Infrastructure.Persistence.Repositories
{
    public class MostWinDuringTheDayRepository : BaseRepository<MostWinDuringTheDay>, IMostWinDuringTheDayRepository
    {
        public MostWinDuringTheDayRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }
    }
}
