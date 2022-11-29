using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Email { get; set;}

        public IEnumerable<SelfAssessmentValue> SelfAssessmentValues { get; set; } =  new List<SelfAssessmentValue>();
        public IEnumerable<Journal> Journals { get; set;} = new List<Journal>();

    }
}
