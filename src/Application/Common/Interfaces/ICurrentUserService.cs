using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public Guid guidUser { get; }
        //public string Email { get; set; }

        //public Guid UserId { get; set; }
        //bool IsAuthenticated { get; set; }
    }
}
