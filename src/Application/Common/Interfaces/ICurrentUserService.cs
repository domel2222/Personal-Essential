using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public Guid guidUser => new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31");
        //public string Email { get; set; }

        //public Guid UserId { get; set; }
        //bool IsAuthenticated { get; set; }
    }
}
