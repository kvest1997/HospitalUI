using Hospital.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalApplication.Services.Interfaces
{
    interface IRegistoryPatientService
    {
        Task<Patient> AddPatient(string secondName,
            string firstName,
            string lastName,
            DateTime bDay,
            string adress,
            int numberPhone);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<IEnumerable<Doctor>> GetDoctorsAsync();
    }
}
