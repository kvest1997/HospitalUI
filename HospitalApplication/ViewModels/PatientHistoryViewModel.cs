using Hospital.DAL.Entityes;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApplication.ViewModels
{
    internal class PatientHistoryViewModel : ViewModel
    {
        private IEnumerable<Appointment> _appointments;
        private Doctor _doctor;
        private Patient _patient;
        public PatientHistoryViewModel(IEnumerable<Appointment> appointments)
        {
            _appointments = appointments;

            _doctor = appointments.FirstOrDefault(x => x.Doctor != null)?.Doctor;
            _patient = appointments.FirstOrDefault(x => x.Patient != null)?.Patient;
        }

        public Doctor Doctor
        {
            get => _doctor;
            set => Set(ref _doctor, value);
        }

        public Patient Patient
        {
            get => _patient;
            set => Set(ref _patient, value);
        }


        public IEnumerable<Appointment> Appointments
        {
            get => _appointments;
            set => Set(ref _appointments, value);
        }
    }
}
