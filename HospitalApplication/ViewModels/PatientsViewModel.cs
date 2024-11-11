using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class PatientsViewModel : ViewModel
    {
        private IRegistoryPatientService _patientService;
        private ObservableCollection<Patient> _patients;

        public PatientsViewModel(IRegistoryPatientService patientService)
        {
            _patientService = patientService;
            LoadPatientAsync();
        }

        #region Propertys
        public ObservableCollection<Patient> Patients 
        { 
            get => _patients; 
            set => Set(ref _patients, value); 
        }
        #endregion

        #region Methods
        private async void LoadPatientAsync()
        {
            Patients = new ObservableCollection<Patient>((await _patientService.GetPatientsAsync()));
        }

        #endregion

        #region Commands

        #region CreatePatientCommand - Создание нового пациента
        private ICommand _сreatePatientCommand;
        private bool CanCreatePatientCommandExecte(object p) => true;
        private void OnCreatePatientCommandExecuted(object p)
        {
            
        }
        public ICommand CreatePatientCommand => _сreatePatientCommand
            ??= new LambdaCommand(OnCreatePatientCommandExecuted, CanCreatePatientCommandExecte);
        #endregion

        #endregion
    }
}
