using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.Results
{
    public class LoginToken
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
