using Hospital.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Services.Interfaces
{
    interface IAccepPatientService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<IEnumerable<Appointment>> GetAppointmentsFromToDateAsync(DateTime fromDate, DateTime toDate);
    }
}
