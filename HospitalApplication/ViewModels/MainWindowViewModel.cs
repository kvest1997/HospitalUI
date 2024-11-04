using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;


namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Patient> _patients;
        private readonly IRegistoryPatientService _patientService;

        private ViewModel _currentViewModel;

        public MainWindowViewModel(IRepository<Patient> patients, 
            IRegistoryPatientService patientService)
        {
            _patients = patients;
            _patientService = patientService;

            Test();
        }

        #region Commands

        #region ShowPatientsViewCommand - Отображение всех пациентов
        private ICommand _showPatientsViewCommand;
        private bool CanShowPatientsViewCommandExecte(object p) => true;
        private void OnShowPatientsViewCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientsViewModel(_patients);
        }
        public ICommand ShowPatientsViewComand => _showPatientsViewCommand 
            ??= new LambdaCommand(OnShowPatientsViewCommandExecuted, CanShowPatientsViewCommandExecte);
        #endregion

        #region ShowPatientRegistrationViewCommand - Отображение регистрации пациента на приеме
        private ICommand _showPatientRegistrationViewCommand;
        private bool CanShowPatientRegistrationViewCommandExecte(object p) => true;
        private void OnShowPatientRegistrationViewCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientRegistrationViewModel();
        }
        public ICommand ShowPatientRegistrationViewCommand => _showPatientRegistrationViewCommand
            ??= new LambdaCommand(OnShowPatientRegistrationViewCommandExecuted, CanShowPatientRegistrationViewCommandExecte);
        #endregion

        #endregion

        #region Property
        /// <summary>
        /// Текущая дочерняя модель-представления
        /// </summary>
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => Set(ref _currentViewModel, value);
        }
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
