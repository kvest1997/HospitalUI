using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;


namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {        
        private readonly IServiceProvider _serviceProvider;

        private readonly IDbRepositoryFactory _dbRepositoryFactory;
        private readonly IRegistoryPatientService _patientService;

        private ViewModel _currentViewModel;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _dbRepositoryFactory = GetRepositoryFactory();
            _patientService = GetRegitoryPatientService();
        }

        #region Commands

        #region OpenPatientsGridCommand - Отображение всех пациентов
        private ICommand _openPatientsGridCommand;
        private bool CanOpenPatientsGridCommandExecte(object p) => true;
        private void OnOpenPatientsGridCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientsViewModel(_patientService, _dbRepositoryFactory);
        }
        public ICommand OpenPatientsGridCommand => _openPatientsGridCommand
            ??= new LambdaCommand(OnOpenPatientsGridCommandExecuted, CanOpenPatientsGridCommandExecte);
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

        private IDbRepositoryFactory GetRepositoryFactory()
        {
            return _serviceProvider.GetRequiredService<IDbRepositoryFactory>();
        }

        private IRegistoryPatientService GetRegitoryPatientService()
        {
            return _serviceProvider.GetRequiredService<IRegistoryPatientService>();
        }

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
