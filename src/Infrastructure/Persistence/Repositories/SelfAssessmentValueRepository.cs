using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class SelfAssessmentValueRepository : BaseRepository<SelfAssessmentValue>, ISelfAssessmentValueRepository
    {
        public SelfAssessmentValueRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }
    }
}
