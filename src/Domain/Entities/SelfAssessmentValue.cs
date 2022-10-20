using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SelfAssessmentValue
    {
        public double DeepWorkResult { get; set; }
        public double AffirmationResult { get; set; }
        public double UsePhoneResult { get; set; }
        public double LearningResult { get; set; }
        public double StepsResult { get; set; }
        public double TrainingResult { get; set; }
        public double CaloriesResult { get; set; }
        public double EnglishTimeResult { get; set; }
        public double AudiobookReadingResult { get; set; }
        public double dailyResult { get; set; }
        public DateOnly assesmentDate { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public Journal Journal { get; set; }
        public Guid JournalId { get; set; }
    }
}
