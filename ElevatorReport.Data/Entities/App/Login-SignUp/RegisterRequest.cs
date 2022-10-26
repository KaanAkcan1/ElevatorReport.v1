using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Entities.App.Login_SignUp
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }

        [PasswordPropertyText(true)]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakterden oluşmalı.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,500}$", ErrorMessage = "Şifreniz en az 8 karakter, küçük, büyük harf, rakam ve özel karakter içermelidir")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Şifreler birbiri ile aynı olmalı")]
        [PasswordPropertyText(true)]
        public string VerifyPassword { get; set; }
    }
}
