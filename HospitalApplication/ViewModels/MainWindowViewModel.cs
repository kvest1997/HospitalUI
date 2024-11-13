using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication;
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
        private readonly IRegistoryPatientService _patientService;

        private ViewModel _currentViewModel;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _patientService = GetRegitoryPatientService();
        }

        #region Commands

        #region OpenPatientsGridCommand - Отображение всех пациентов
        private ICommand _openPatientsGridCommand;
        private bool CanOpenPatientsGridCommandExecte(object p) => true;
        private void OnOpenPatientsGridCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientsViewModel(_patientService);
        }
        public ICommand OpenPatientsGridCommand => _openPatientsGridCommand
            ??= new LambdaCommand(OnOpenPatientsGridCommandExecuted, CanOpenPatientsGridCommandExecte);
        #endregion

        #region ShowPatientRegistrationViewCommand - Отображение регистрации пациента на приеме
        private ICommand _showPatientRegistrationViewCommand;
        private bool CanShowPatientRegistrationViewCommandExecte(object p) => true;
        private void OnShowPatientRegistrationViewCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientRegistrationViewModel(_patientService);
        }
        public ICommand ShowPatientRegistrationViewCommand => _showPatientRegistrationViewCommand
            ??= new LambdaCommand(OnShowPatientRegistrationViewCommandExecuted, CanShowPatientRegistrationViewCommandExecte);
        #endregion

        #region CloseCommand - Отображение регистрации пациента на приеме
        private ICommand _closeCommand;
        private bool CanCloseCommanddExecte(object p) => true;
        private void OnCloseCommandExecuted(object p)
        {
            
        }
        public ICommand CloseCommand => _showPatientRegistrationViewCommand
            ??= new LambdaCommand(OnCloseCommandExecuted, CanCloseCommanddExecte);
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

        private IRegistoryPatientService GetRegitoryPatientService()
        {
            return _serviceProvider.GetRequiredService<IRegistoryPatientService>();
        }
        #endregion
    }
}
