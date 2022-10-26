using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Results
{
    public class DataResponse<TKey>
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
        public TKey Data { get; set; } 
    }
}
