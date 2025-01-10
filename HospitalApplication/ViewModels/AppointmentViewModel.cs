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
        private IAccepPatientService _acceptPatientService;

        private ExaminationResultDto _examinationResult = new ExaminationResultDto();
        private PrescribedTreatmentDto _prescribedTreatment = new PrescribedTreatmentDto();

        private ObservableCollection<Diagnosis> _diagnosesOptions;
        private ObservableCollection<Analysis> _analyses;

        public AppointmentViewModel(Appointment appointment, 
            IEnumerable<Diagnosis> diagnoses, 
            IEnumerable<Analysis> analyses, 
            IAccepPatientService accepPatientService)
        {
            _appointment = appointment;
            _diagnosesOptions = new ObservableCollection<Diagnosis>(diagnoses);
            _analyses = new ObservableCollection<Analysis>(analyses);
            _acceptPatientService = accepPatientService;
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
        private async void OnSaveAppointmentCommandExecuted(object p)
        {
            var examination = await _acceptPatientService.PostExaminationResult(new Hospital.DAL.Entityes.ExaminationResult
            {

                AppointmentId = Appointment.Id,
                DisabilityPeriod = ExaminationResult.DisabilityPeriod,
                DiagnosesId = ExaminationResult.DiagnosesId,
                Dispansary = ExaminationResult.Dispansary,
                OutpatientTreatment = ExaminationResult.OutpatientTreatment,
                Note = ExaminationResult.Note
            });

            var prescribedTreatment = new PrescribedTreatment
            {
                Procedur = PrescribedTreatment.Procedur,
                AnalysesId = PrescribedTreatment.AnalysesId,
                Treatment = PrescribedTreatment.Treatment,
                ExaminationResultsId = examination.Id
            };

            await _acceptPatientService.PostAppointmentResult(prescribedTreatment);
        }

        public ICommand SaveAppointmentCommand => _saveAppointmentCommand
            ??= new LambdaCommand(OnSaveAppointmentCommandExecuted, CanSaveAppointmentCommandExecte);

        #endregion

        #endregion
    }
}
