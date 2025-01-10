using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Services
{
    internal class AccepPatientService : IAccepPatientService
    {
        private readonly IRepository<Appointment> _appointments;
        private readonly IRepository<Diagnosis> _diagnosis;
        private readonly IRepository<Analysis> _analyses;
        private readonly IRepository<PrescribedTreatment> _prescribedTreatment;
        private readonly IRepository<ExaminationResult> _examinationResult;

        public AccepPatientService(IDbRepositoryFactory dbRepositoryFactory)
        {
            _appointments = dbRepositoryFactory.CreateRepository<Appointment>();
            _diagnosis = dbRepositoryFactory.CreateRepository<Diagnosis>();
            _analyses = dbRepositoryFactory.CreateRepository<Analysis>();
            _prescribedTreatment = dbRepositoryFactory.CreateRepository<PrescribedTreatment>();
            _examinationResult = dbRepositoryFactory.CreateRepository<ExaminationResult>();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync() => await _appointments.Items.ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsFromToDateAsync(DateTime fromDate, DateTime toDate) => 
            await _appointments.Items
            .Where(item => item.DateAppointment >= fromDate && 
                    item.DateAppointment <= toDate).ToListAsync();

        public async Task<IEnumerable<Diagnosis>> GetDiagnosesAsync() => await _diagnosis.Items.ToListAsync();

        public async Task<IEnumerable<Analysis>> GetAnalysesAsync() => await _analyses.Items.ToListAsync();

        public async Task<ExaminationResult> PostExaminationResult(ExaminationResult examinationResult) 
        {
            return await _examinationResult.AddAsync(examinationResult);
        }

        public async Task PostAppointmentResult(PrescribedTreatment prescribedTreatment)
        {
            await _prescribedTreatment.AddAsync(prescribedTreatment);   
        }
    }
}
