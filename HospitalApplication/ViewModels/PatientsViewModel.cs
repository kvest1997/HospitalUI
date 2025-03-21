﻿using Hospital.DAL.Entityes;
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
        private IUserDialog _userDialog;

        public PatientsViewModel(IRegistoryPatientService patientService, IUserDialog userDialog)
        {
            _patientService = patientService;
            _userDialog = userDialog;
            LoadPatientAsync();
        }

        #region Propertys

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }

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
        private async void OnCreatePatientCommandExecuted(object p)
        {
            var newPatient = new Patient();

            if (!_userDialog.Add(newPatient)) return;

            Patients.Add(await _patientService.AddPatient(newPatient));
        }
        public ICommand CreatePatientCommand => _сreatePatientCommand
            ??= new LambdaCommand(OnCreatePatientCommandExecuted, CanCreatePatientCommandExecte);
        #endregion

        #region EditPatientCommand - редактирование пациента
        private ICommand _editPatientCommand;
        private bool CanEditPatientCommandExecte(object p) => true;
        private async void OnEditPatientCommandExecuted(object p)
        {
            var editPatient = SelectedPatient;

            if (!_userDialog.Add(editPatient)) return;

            await _patientService.UpdatePatient(editPatient);

            Patients = new ObservableCollection<Patient>(await _patientService.GetPatientsAsync());
        }
        public ICommand EditPatientCommand => _editPatientCommand
            ??= new LambdaCommand(OnEditPatientCommandExecuted, CanEditPatientCommandExecte);
        #endregion

        #region RemovePatientCommand - Удаление пациента
        private ICommand _removePatientCommand;
        private bool CanRemovePatientCommandExecte(object p) => true;
        private async void OnRemovePatientCommandExecuted(object p)
        {
            var removePatient = SelectedPatient;


            if (!_userDialog.ConfirmWarning($"Вы хотите удалить пациента {removePatient.FullName}?", "Удаление пациента")) return;

            await _patientService.RemovePatient(removePatient.Id);
            Patients.Remove(removePatient);

            if (ReferenceEquals(SelectedPatient, removePatient))
                SelectedPatient = null;
        }
        public ICommand RemovePatientCommand => _removePatientCommand
            ??= new LambdaCommand(OnRemovePatientCommandExecuted, CanRemovePatientCommandExecte);
        #endregion

        #region OpenHistoryCommand - Просмотр истории пациента
        private ICommand _openHistoryCommand;
        private bool CanOpenHistoryCommandExecte(object p) => true;
        private async void OnOpenHistoryCommandExecuted(object p)
        {
            var appointments = SelectedPatient.Appointments;

            if (!_userDialog.OpenHistory(appointments)) return;
        }
        public ICommand OpenHistoryCommand => _openHistoryCommand
            ??= new LambdaCommand(OnOpenHistoryCommandExecuted, CanOpenHistoryCommandExecte);
        #endregion

        #endregion
    }
}
