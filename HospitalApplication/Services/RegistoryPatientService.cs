using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.Services
{
    class RegistoryPatientService : IRegistoryPatientService
    {
        private readonly IRepository<Patient> _patients;
        private readonly IRepository<Doctor> _doctors;
        private readonly IRepository<Appointment> _appointments;
        private readonly IRepository<Hospitals> _hospitals;

        public RegistoryPatientService(IDbRepositoryFactory dbRepositoryFactory)
        {
            _patients = dbRepositoryFactory.CreateRepository<Patient>();
            _doctors = dbRepositoryFactory.CreateRepository<Doctor>();
            _appointments = dbRepositoryFactory.CreateRepository<Appointment>();
            _hospitals = dbRepositoryFactory.CreateRepository<Hospitals>();
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _patients.Items.ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _doctors.Items.ToListAsync();
        }

        public async Task<IEnumerable<Hospitals>> GetHospitalsAsync()
        {
            return await _hospitals.Items.ToListAsync();
        }

        public async Task<Appointment> RegisterPatient(int patientId,
            int hospitalId,
            int doctorId,
            DateTime dateAppointment,
            TimeSpan timeAppointment)
        {
            var appointent = new Appointment
            {
                PatientId = patientId,
                HospitalId = hospitalId,
                DoctorId = doctorId,
                DateAppointment = dateAppointment,
                TimeAppointment = timeAppointment
            };

            return await _appointments.AddAsync(appointent);
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            return await _patients.AddAsync(patient);
        }

        public async Task UpdatePatient(Patient patient)
        {
            await _patients.UpdateAsync(patient);
        }

        public async Task RemovePatient(int id)
        {
            await _patients.RemoveAsync(id);
        }
    }
}
