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
    public class SelfAssessmentValueConfiguration : IEntityTypeConfiguration<SelfAssessmentValue>
    {
        public void Configure(EntityTypeBuilder<SelfAssessmentValue> builder)
        {
            builder.Property(x => x.AffirmationResult).HasDefaultValue(0.0);
            builder.Property(x => x.AudiobookReadingResult).HasDefaultValue(0.0);
            builder.Property(x => x.CaloriesResult).HasDefaultValue(0.0);
            builder.Property(x => x.DailyResult).HasDefaultValue(0.0);
            builder.Property(x => x.DeepWorkResult).HasDefaultValue(0.0);
            builder.Property(x => x.EnglishTimeResult).HasDefaultValue(0.0);
            builder.Property(x => x.LearningResult).HasDefaultValue(0.0);
            builder.Property(x => x.StepsResult).HasDefaultValue(0.0);
            builder.Property(x => x.TrainingResult).HasDefaultValue(0.0);
            builder.Property(x => x.UsePhoneResult).HasDefaultValue(0.0);
        }
    }
}
