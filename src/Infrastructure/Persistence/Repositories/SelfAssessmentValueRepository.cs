namespace Infrastructure.Persistence.Repositories
{
    public class SelfAssessmentValueRepository : BaseRepository<SelfAssessmentValue>, ISelfAssessmentValueRepository
    {
        public SelfAssessmentValueRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }
    }
}
