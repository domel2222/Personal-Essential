using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private Guid guidUser = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31");

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = guidUser,
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    FirstName = "Dominik",
                    LastName = "Wikliński",
                    Email = "domel2222@gmail.com"
                });
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Email)
                    .IsRequired();

            builder.HasIndex(u => u.Email);

            builder.HasMany(j => j.Journals)
                    .WithOne(j => j.User)
                    .HasForeignKey(j => j.UserId);

            builder.HasMany(s => s.SelfAssessmentValues)
                    .WithOne(s => s.User)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.ClientCascade);
           
        }
    }
}