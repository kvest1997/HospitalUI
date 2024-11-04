using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalApplication.Services
{
    class RegistoryPatientService : IRegistoryPatientService
    {
        private readonly IRepository<Patient> _patients;
        public RegistoryPatientService(IRepository<Patient> patients)
        {
            _patients = patients;
        }

        public IEnumerable<Patient> Patients => _patients.Items;

        public async Task<Patient> AddPatient(string secondName, 
            string firstName,
            string lastName,
            DateTime bDay,
            string adress,
            int numberPhone)
        {
            var patient = new Patient
            {
                SecondName = secondName,
                FirstName = firstName,
                LastName = lastName,
                Birthday = bDay,
                Adress = adress,
                NumberPhone = numberPhone
            };

            return await _patients.AddAsync(patient);
        }
    }
}
