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
                new Strenght() {Id = Guid.NewGuid(), Name = "Responsibility" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Achiever" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Focus" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Learner" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Individualization" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Self-Assurance" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Activator" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Futuristic" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Connectedness" },
                new Strenght() {Id = Guid.NewGuid(), Name = "Relator" }                       
                );
        }
    }
}
