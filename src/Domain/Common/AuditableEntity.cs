using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; } //guid 
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? InactivatedBy { get; set; }
        public DateTime? InactivatedDate { get; set; } 

    }
}
