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
    public class StrenghtConfiguration : IEntityTypeConfiguration<Strenght>
    {
        private Guid guidUser = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31");
        public void Configure(EntityTypeBuilder<Strenght> builder)
        {
            builder.Property(s => s.Name).HasColumnType("nvarchar(100)");

            builder.HasMany(s => s.MostWinsDuringTheDay)
                   .WithOne(s => s.Strenght)
                   .HasForeignKey(s => s.StrenghtId);
            //"CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate"
            builder.HasData(
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Responsibility"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Achiever"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Focus"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Learner"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Individualization"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Self-Assurance"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Activator"
                },
                new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Futuristic"
                }, new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Connectedness"
                }, new Strenght()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Relator"
                });
        }
    }
}
