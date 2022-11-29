using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PersonalDbContext : DbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public PersonalDbContext(DbContextOptions<PersonalDbContext> options, IDateTime dateTime, ICurrentUserService currentUserService) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public DbSet<Journal>? Journals { get; set; }
        public DbSet<Strenght>? Strenghts { get; set; }
        public DbSet<MostWinDuringTheDay>? MostWins { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<SelfAssessmentValue>? SelfAssessmentValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedBy = _currentUserService.guidUser;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.guidUser;
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = _currentUserService.guidUser;
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.InactivatedBy = _currentUserService.guidUser;
                        entry.Entity.InactivatedDate = _dateTime.Now;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}