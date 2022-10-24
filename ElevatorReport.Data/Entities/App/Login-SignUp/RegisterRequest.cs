using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.App.Login_SignUp
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
    }
}
