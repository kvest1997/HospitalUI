using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoruesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Analysis>, DbRepository<Analysis>>()
            .AddTransient<IRepository<Appointment>, DbRepository<Appointment>>()
            .AddTransient<IRepository<Diagnosis>, DbRepository<Diagnosis>>()
            .AddTransient<IRepository<Doctor>, DbRepository<Doctor>>()
            .AddTransient<IRepository<ExaminationResult>, DbRepository<ExaminationResult>>()
            .AddTransient<IRepository<Entityes.Hospital>, DbRepository<Entityes.Hospital>>()
            .AddTransient<IRepository<Patient>, DbRepository<Patient>>()
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<PrescribedTreatment>, DbRepository<PrescribedTreatment>>()
            .AddTransient<IRepository<Specialization>, DbRepository<Specialization>>()
            .AddTransient<IRepository<Staff>, DbRepository<Staff>>();
    }
}
