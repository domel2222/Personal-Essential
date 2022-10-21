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
    public class MostWinDuringTheDayConfiguration : IEntityTypeConfiguration<MostWinDuringTheDay>
    {
        public void Configure(EntityTypeBuilder<MostWinDuringTheDay> builder)
        {
            builder.Property(m => m.Message).HasColumnType("nvarchar(500)");
        }
    }
}
