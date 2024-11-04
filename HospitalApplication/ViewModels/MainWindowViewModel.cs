using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using HospitalUI.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Patient> _patients;
        private readonly IRegistoryPatientService _patientService;

        #region Title : string - Заголовок

        /// <summary>Заголовок</summary>
        private string _Title = "Тест окна";

        /// <summary>Заголовок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        public MainWindowViewModel(IRepository<Patient> patients, 
            IRegistoryPatientService patientService)
        {
            _patients = patients;
            _patientService = patientService;

            Test();
        }

        #region Property
        public IEnumerable<Patient> Patients=>_patients.Items.Take(10).ToList();
        #endregion

        #region Methods
        private async void Test()
        {
            var pat_count = _patientService.Patients.Count();

            var addPatient = await _patientService.AddPatient("Тест1sName", "Тест1fName",
                "Тест1lName", DateTime.Now, "TestAddres", 895223);

            var pat_count2 = _patientService.Patients.Count();
        }
        #endregion
    }
}
