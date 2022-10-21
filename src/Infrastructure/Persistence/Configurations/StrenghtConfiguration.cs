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
        public void Configure(EntityTypeBuilder<Strenght> builder)
        {
            builder.Property(s => s.Name).HasColumnType("nvarchar(100)");

            builder.HasMany(s => s.MostWinsDuringTheDay)
                   .WithOne(s => s.Strenght)
                   .HasForeignKey(s => s.StrenghtId);

            builder.HasData(
                new Strenght() { Name = "Responsibility" },
                new Strenght() { Name = "Achiever" },
                new Strenght() { Name = "Focus" },
                new Strenght() { Name = "Learner" },
                new Strenght() { Name = "Individualization" },
                new Strenght() { Name = "Self-Assurance" },
                new Strenght() { Name = "Activator" },
                new Strenght() { Name = "Futuristic" },
                new Strenght() { Name = "Connectedness" },
                new Strenght() { Name = "Relator" }
                );
        }
    }
}
