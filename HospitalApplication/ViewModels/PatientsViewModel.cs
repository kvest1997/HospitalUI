using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class PatientsViewModel : ViewModel
    {
        private IDbRepositoryFactory _dbRepositoryFactory;
        private IRegistoryPatientService _patientService;
        private readonly IRepository<Patient> _patients;

        public PatientsViewModel(IRegistoryPatientService patientService, IDbRepositoryFactory dbRepositoryFactory)
        {
            _dbRepositoryFactory = dbRepositoryFactory;
            _patientService = patientService;

            _patients = _dbRepositoryFactory.CreateRepository<Patient>();
        }


        #region Propertys
        public IEnumerable<Patient> Patients => _patients.Items.ToList();

        #endregion

        #region Methods
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
