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

        public AccepPatientService(IDbRepositoryFactory dbRepositoryFactory)
        {
            _appointments = dbRepositoryFactory.CreateRepository<Appointment>();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync() => await _appointments.Items.ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsFromToDateAsync(DateTime fromDate, DateTime toDate) => 
            await _appointments.Items
            .Where(item => item.DateAppointment >= fromDate && 
                    item.DateAppointment <= toDate).ToListAsync();
    }
}
