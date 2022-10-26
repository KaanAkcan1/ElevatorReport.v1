using ElevatorReport.Data.Contexts;
using ElevatorReport.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElevatorReport.Data
{
    public static class ServiceRegistration
    {//Servislerin tanımlandığı katman
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddTransient<UserService>();
            services.AddTransient<AccountService>();
            
        }
    }
}
