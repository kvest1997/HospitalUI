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

        private ExaminationResultDto _examinationResult;
        private PrescribedTreatmentDto _prescribedTreatment = new PrescribedTreatmentDto();

        private ObservableCollection<Diagnosis> _diagnosesOptions;
        private ObservableCollection<Analysis> _analyses;

        public AppointmentViewModel(Appointment appointment, IEnumerable<Diagnosis> diagnoses, IEnumerable<Analysis> analyses)
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

        #region Methods

        #endregion

        #region Commands

        #region SaveAppointment - Сохранить данные приема
        private ICommand _saveAppointmentCommand;
        private bool CanSaveAppointmentCommandExecte(object p) => true;
        private void OnSaveAppointmentCommandExecuted(object p)
        {
            var prescribedTreatment = new PrescribedTreatment
            {
                Procedur = _prescribedTreatment.Procedur,
                AnalysesId = _prescribedTreatment.AnalysesId
            };

            
        }

        public ICommand SaveAppointmentCommand => _saveAppointmentCommand
            ??= new LambdaCommand(OnSaveAppointmentCommandExecuted, CanSaveAppointmentCommandExecte);

        #endregion

        #endregion
    }
}
