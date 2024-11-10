using Hospital.DAL;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalApplication.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IRegistoryPatientService, RegistoryPatientService>()
            .AddScoped<IDbRepositoryFactory, DbRepositoryFactory>()
            ;
    }
}
