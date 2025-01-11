using Hospital.DAL.Entityes;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HospitalApplication.ViewModels
{
    internal class PatientHistoryViewModel : ViewModel
    {
        private IEnumerable<Appointment> _appointments;
        private ObservableCollection<PrescribedTreatment> _prescribedTreatments;
        private ObservableCollection<ExaminationResult> _examinationResults;

        private Doctor _doctor;
        private Patient _patient;

        private Appointment _selectedAppointment;
        private ExaminationResult _selectedExaminationResult;
        private PrescribedTreatment _selectedPrescribedTreatment;

        public PatientHistoryViewModel(IEnumerable<Appointment> appointments)
        {
            _appointments = appointments;

            _doctor = appointments.FirstOrDefault(x => x.Doctor != null)?.Doctor;
            _patient = appointments.FirstOrDefault(x => x.Patient != null)?.Patient;
        }

        public ExaminationResult SelectedExaminationResults
        {
            get => _selectedExaminationResult;
            set
            {
                Set(ref _selectedExaminationResult, value);

                if(_selectedExaminationResult != null)
                    PrescribedTreatments = new ObservableCollection<PrescribedTreatment>(_selectedExaminationResult.PrescribedTreatments);
            }
        }

        public PrescribedTreatment SelectedPrescribedTreatment
        {
            get => _selectedPrescribedTreatment;
            set => Set(ref _selectedPrescribedTreatment, value);
        }

        public Appointment SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                Set(ref _selectedAppointment, value);

                SelectedExaminationResults = null;
                SelectedPrescribedTreatment = null;
                PrescribedTreatments = null;

                ExaminationResults = new ObservableCollection<ExaminationResult>(_selectedAppointment.ExaminationResults);
            }
        }

        public ObservableCollection<PrescribedTreatment> PrescribedTreatments
        {
            get => _prescribedTreatments;
            set => Set(ref _prescribedTreatments, value);
        }

        public ObservableCollection<ExaminationResult> ExaminationResults
        {
            get => _examinationResults;
            set => Set(ref _examinationResults, value);
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
