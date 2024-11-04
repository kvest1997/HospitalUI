using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalUI.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApplication.ViewModels
{
    internal class PatientsViewModel : ViewModel
    {
        private readonly IRepository<Patient> _patients;

        public PatientsViewModel(IRepository<Patient> patients)
        {
            _patients = patients;
        }

        public IEnumerable<Patient> Patients => _patients.Items.Take(10).ToList();
    }
}
