using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PersonalDbContext : DbContext
    {

        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;
        public PersonalDbContext(DbContextOptions<PersonalDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime ) : base (options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
