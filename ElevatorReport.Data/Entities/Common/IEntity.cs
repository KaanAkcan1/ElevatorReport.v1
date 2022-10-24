using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Common
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }

        int StatusId { get; set; }

        string StatusText { get; set; }

        DateTime CreatedOn { get; set; }

        Guid CreatedBy { get; set; }

        string CreatedByUserFullname { get; set; }

        DateTime ModifiedOn { get; set; }

        Guid ModifiedBy { get; set; }

        string ModifiedByUserFullname { get; set; }
    }
}
