using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    FirstName = "Dominik",
                    LastName = "Wikliński",
                    Email = "domel2222@gmail.com"

                });
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(100)");
            builder.Property(x => x.LastName).HasColumnType("nvarchar(100)");

            builder.HasMany(j => j.Journals)
                    .WithOne(j => j.User)
                    .HasForeignKey(j => j.UserId);

            builder.HasMany(s => s.SelfAssessmentValues)
                    .WithOne(s => s.User)
                    .HasForeignKey(s => s.UserId);
        }
    }
}
