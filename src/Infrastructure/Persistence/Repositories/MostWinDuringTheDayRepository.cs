using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class MostWinDuringTheDayRepository : BaseRepository<MostWinDuringTheDay>, IMostWinDuringTheDayRepository
    {
        public MostWinDuringTheDayRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }
    }
}
