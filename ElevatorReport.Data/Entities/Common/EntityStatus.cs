using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Common
{
    public enum EntityStatus
    {
        Deleted = -1,
        Undefined = 0,
        Active = 1,
        Passive = 2,
    }
}
