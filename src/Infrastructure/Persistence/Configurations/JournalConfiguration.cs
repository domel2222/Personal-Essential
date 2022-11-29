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
    public class JournalConfiguration : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.Property(j => j.Title).HasColumnType("nvarchar(200)");
            builder.Property(j => j.Text).HasColumnType("nvarchar");

            builder.HasMany(j => j.MostWinsDuringTheDay)
                   .WithOne(j => j.Journal)
                   .HasForeignKey(j => j.JournalId);

            builder.HasMany(j => j.SelfAssessmentsValue)
                    .WithOne(j => j.Journal)
                    .HasForeignKey(j => j.JournalId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
