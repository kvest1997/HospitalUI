using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalApplication.ViewModels
{
    internal class PatientRegistrationViewModel : ViewModel
    {
        private readonly IRegistoryPatientService _registoryPatientService;

        private ObservableCollection<Patient> _patients;
        private Patient _selectedPatient;

        private ObservableCollection<Doctor> _doctors;
        private Doctor _selectedDoctor;

        private DateTime _appointmentDate;

        public PatientRegistrationViewModel(IRegistoryPatientService registoryPatientService)
        {
            _registoryPatientService = registoryPatientService;
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

        #endregion

        #region Methods
        private async void InitializeDateAsync()
        {
            Patients = new ObservableCollection<Patient>(await _registoryPatientService.GetPatientsAsync());
            Doctors = new ObservableCollection<Doctor>(await _registoryPatientService.GetDoctorsAsync());
        }
        #endregion


    }
}
