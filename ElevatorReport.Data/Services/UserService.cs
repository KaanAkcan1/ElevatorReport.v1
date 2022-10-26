using ElevatorReport.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performans.NetCore.Data;
using ElevatorReport.Data.Contexts;
using ElevatorReport.Data.Entities.App.Login_SignUp;
using Microsoft.AspNetCore.Identity;
using ElevatorReport.Data.Entities.Results;

namespace ElevatorReport.Data.Services
{
    public class UserService : Repository<Guid, User>
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<Response> CreateUserAsync(RegisterRequest request, Guid id)
        {
            var user = new User()
            {
                Token = 0,
                Id = id,
                Username = request.Username,
                Email = request.Email
            };

            await InsertUpdateAsync(user, CancellationToken.None);

            return new Response { Success = true};
        }
    }
}
