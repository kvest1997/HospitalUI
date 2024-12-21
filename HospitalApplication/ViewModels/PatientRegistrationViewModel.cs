using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class PatientRegistrationViewModel : ViewModel
    {
        private readonly IRegistoryPatientService _registoryPatientService;

        private ObservableCollection<Patient> _patients;
        private Patient _selectedPatient;

        private ObservableCollection<Doctor> _doctors;
        private Doctor _selectedDoctor;

        private ObservableCollection<Hospitals> _hospitals;
        private Hospitals _selectedHospital;

        private DateTime _appointmentDate = DateTime.Now;

        public PatientRegistrationViewModel(IRegistoryPatientService registoryPatientService)
        {
            _registoryPatientService = registoryPatientService;
            InitializeDateAsync();
            AppointmentDate = AppointmentDate.AddDays(7);
        }

        #region Propertys
        public DateTime AppointmentDate
        {
            get => _appointmentDate;
            set => Set(ref _appointmentDate, value);
        }

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set => Set(ref _patients, value);
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }

        public ObservableCollection<Doctor> Doctors
        {
            get => _doctors;
            set => Set(ref _doctors, value);
        }

        public Doctor SelectedDoctor
        {
            get => _selectedDoctor;
            set => Set(ref _selectedDoctor, value);
        }

        public ObservableCollection<Hospitals> AllHospitals
        {
            get => _hospitals;
            set => Set(ref _hospitals, value);
        }

        public Hospitals SelectedHospital
        {
            get => _selectedHospital;
            set => Set(ref _selectedHospital, value);
        }

        #endregion

        #region Methods
        private async void InitializeDateAsync()
        {
            Patients = new ObservableCollection<Patient>(await _registoryPatientService.GetPatientsAsync());
            Doctors = new ObservableCollection<Doctor>(await _registoryPatientService.GetDoctorsAsync());
            AllHospitals = new ObservableCollection<Hospitals>(await _registoryPatientService.GetHospitalsAsync());
        }
        #endregion

        #region Commands

        #region RegisterPatientCommand - Запись пациента на прием
        private ICommand _registerPatientCommand;
        private bool CanRegisterPatientCommandExecte(object p) => true;
        private void OnRegisterPatientCommandExecuted(object p)
        {
            var appointemnt = _registoryPatientService.RegisterPatient(_selectedPatient.Id, _selectedHospital.Id, _selectedDoctor.Id, AppointmentDate, DateTime.Now.TimeOfDay);

            if (appointemnt != null)
                MessageBox.Show("Пациент записан", "Записан", MessageBoxButton.OK);
            else
                throw new Exception("Ошибка записи");

        }
        public ICommand RegisterPatientCommand => _registerPatientCommand
            ??= new LambdaCommand(OnRegisterPatientCommandExecuted, CanRegisterPatientCommandExecte);
        #endregion

        #endregion

    }
}
