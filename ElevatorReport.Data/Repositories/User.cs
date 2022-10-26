using ElevatorReport.Data.Entities.Common;
using Performans.NetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Repositories
{
    public class User : AuditableEntity/*, BaseEntity<Guid>*/
    {
        public int Token { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
