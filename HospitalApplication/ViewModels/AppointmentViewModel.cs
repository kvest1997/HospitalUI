using Hospital.DAL.Entityes;
using HospitalApplication.Model;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class AppointmentViewModel : ViewModel
    {
        private Appointment _appointment;

        private ExaminationResultDto _examinationResult = new ExaminationResultDto();
        private PrescribedTreatmentDto _prescribedTreatment = new PrescribedTreatmentDto();

        private ObservableCollection<Diagnosis> _diagnosesOptions;
        private ObservableCollection<Analysis> _analyses;

        public AppointmentViewModel(Appointment appointment, 
            IEnumerable<Diagnosis> diagnoses, 
            IEnumerable<Analysis> analyses, ExaminationResult examinationResult,
            PrescribedTreatment prescribedTreatment)
        {
            _appointment = appointment;
            _diagnosesOptions = new ObservableCollection<Diagnosis>(diagnoses);
            _analyses = new ObservableCollection<Analysis>(analyses);
        }

        #region Property
        public ObservableCollection<Analysis> Analyses => _analyses;

        public ObservableCollection<Diagnosis> DiagnosesOptions => _diagnosesOptions;

        public ExaminationResultDto ExaminationResult 
        { 
            get => _examinationResult; 
            set => Set(ref _examinationResult, value); 
        }

        public PrescribedTreatmentDto PrescribedTreatment
        {
            get => _prescribedTreatment;
            set => Set(ref _prescribedTreatment, value);
        }

        public Doctor Doctor => _appointment.Doctor;

        public Patient Patient => _appointment.Patient;

        public Appointment Appointment
        {
            get => _appointment;
            set => Set(ref _appointment, value);
        }
        #endregion
    }
}
