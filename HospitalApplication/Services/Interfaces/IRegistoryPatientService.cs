using Hospital.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalApplication.Services.Interfaces
{
    interface IRegistoryPatientService
    {
        Task<Patient> AddPatient(Patient patient);

        Task UpdatePatient(Patient patient);

        Task<Appointment> RegisterPatient(int patientId, 
            int hospitalId, 
            int doctorId,
            DateTime dateAppointment,
            TimeSpan timeAppointment);

        Task RemovePatient(int id);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<IEnumerable<Hospitals>> GetHospitalsAsync();
    }
}
