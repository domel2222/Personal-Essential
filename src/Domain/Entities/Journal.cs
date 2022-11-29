using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Journal : AuditableEntity
    {
        public string? Title { get; set;}
        public string? Text { get; set;}
        public DateTime DiaryDate { get; set;}
       
        public User? User { get; set;}
        public Guid UserId { get; set;}

        public IEnumerable<SelfAssessmentValue> SelfAssessmentsValue { get; set;} = new List<SelfAssessmentValue>();
        public IEnumerable<MostWinDuringTheDay> MostWinsDuringTheDay { get; set; } = new List<MostWinDuringTheDay>();
    }
}
