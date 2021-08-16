using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflixAPI.Data;
using netflixAPI.Domain;
using netflixAPI.Services;

namespace netflixAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IUserProgramService, UserProgramService>();
            services.AddScoped<IProgramTypeService, ProgramTypeService>();
        }
    }
}