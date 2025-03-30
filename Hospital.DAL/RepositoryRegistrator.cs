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
            .AddTransient<IRepository<Appointment>, AppointmentsRepository>()
            .AddTransient<IRepository<Diagnosis>, DbRepository<Diagnosis>>()
            .AddTransient<IRepository<Doctor>, DoctorsRepository>()
            .AddTransient<IRepository<ExaminationResult>, ExaminationResultsRepository>()
            .AddTransient<IRepository<Hospitals>, HospitalRepository>()
            .AddTransient<IRepository<Patient>, PatientRepository>()
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<PrescribedTreatment>, PrescribedTreatmentsRepository>()
            .AddTransient<IRepository<Specialization>, DbRepository<Specialization>>()
            .AddTransient<IRepository<Staff>, StaffRepository>()
            .AddTransient<IRepository<Operations>, DbRepository<Operations>>()
            .AddTransient<IRepository<OperationTypes>, DbRepository<OperationTypes>>();
    }
}
