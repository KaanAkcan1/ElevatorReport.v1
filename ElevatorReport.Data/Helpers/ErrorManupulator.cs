using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorReport.Data.Helpers
{
    public static class ErrorManupulator
    {
        public static string ErrorArrayToString(IEnumerable<IdentityError> errors)
        {
            var result = string.Empty;

            var errorList = errors.ToList();

            foreach (var error in errorList)
            {
                result += error.Description;
            }
            return result;
        }
    }
}
