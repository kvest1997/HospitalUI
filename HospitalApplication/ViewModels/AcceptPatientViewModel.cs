﻿using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class AcceptPatientViewModel : ViewModel
    {
        private readonly IAccepPatientService _accepPatientService;
        private readonly IUserDialog _userDialog;

        private ObservableCollection<Appointment> _appointments;
        private IEnumerable<Diagnosis> _diagnoses;
        private IEnumerable<Analysis> _analyses;
        private IEnumerable<PrescribedTreatment> _prescribedTreatments;

        private Appointment _selectedAppointment;

        private DateTime _fromDate = DateTime.Now;
        private DateTime _toDate = DateTime.Now;

        public AcceptPatientViewModel(IAccepPatientService accepPatientService, 
            IUserDialog userDialog) 
        {
            _accepPatientService = accepPatientService;
            _userDialog = userDialog;
            InitializeDateAsync();
        }

        #region Propertys
        /// <summary>
        /// От какого числа смотреть
        /// </summary>
        public DateTime FromDate
        {
            get => _fromDate;
            set => Set(ref _fromDate, value);
        }

        /// <summary>
        /// По какое число смотреть
        /// </summary>
        public DateTime ToDate
        {
            get => _toDate;
            set => Set(ref _toDate, value);
        }

        public Appointment SelectedAppointment
        {
            get => _selectedAppointment;
            set => Set(ref _selectedAppointment, value);
        }

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set => Set(ref _appointments, value);
        }
        #endregion

        #region Methods
        private async void InitializeDateAsync()
        {
            Appointments = new ObservableCollection<Appointment>(await _accepPatientService.GetAppointmentsFromToDateAsync(FromDate, ToDate));
            _diagnoses = await _accepPatientService.GetDiagnosesAsync();
            _analyses = await _accepPatientService.GetAnalysesAsync();
            FromDate = DateTime.Now;
            ToDate = ToDate.AddDays(7);
        }
        #endregion

        #region Commands

        #region FindAppointmentsToDateCommand - Показать записи по датам
        private ICommand _findAppointmentsToDateCommand;
        private bool CanFindAppointmentsToDateCommandExecte(object p) => true;
        private async void OnFindAppointmentsToDateCommandExecuted(object p)
        {
            Appointments = new ObservableCollection<Appointment>(await _accepPatientService.GetAppointmentsFromToDateAsync(FromDate, ToDate));
        }
        public ICommand FindAppointmentsToDateCommand => _findAppointmentsToDateCommand
            ??= new LambdaCommand(OnFindAppointmentsToDateCommandExecuted, CanFindAppointmentsToDateCommandExecte);
        #endregion

        #region GetAllAppointmentsCommand - Показать все записи
        private ICommand _getAllAppointmentsCommand;
        private bool CanGetAllAppointmentsCommandExecte(object p) => true;
        private async void OnGetAllAppointmentsCommandExecuted(object p)
        {
            Appointments = new ObservableCollection<Appointment>(await _accepPatientService.GetAppointmentsAsync());
        }
        public ICommand GetAllAppointmentsCommand => _getAllAppointmentsCommand
            ??= new LambdaCommand(OnGetAllAppointmentsCommandExecuted, CanGetAllAppointmentsCommandExecte);
        #endregion

        #region ShowAppointmentPatient - Просмотр приема
        private ICommand _showAppointmentPatientCommand;
        private bool CanShowAppointmentPatientCommandExecte(object p) => true;
        private async void OnShowAppointmentPatientCommandExecuted(object p)
        {
            var examinationResult = new ExaminationResult();
            var prescribedTreatment = new PrescribedTreatment();

            if (!_userDialog.OpenAppointment(SelectedAppointment, 
                _diagnoses, 
                _analyses, 
                examinationResult, prescribedTreatment)) 
                return;

            await _accepPatientService.PostExaminationResult(examinationResult);
            await _accepPatientService.PostAppointmentResult(prescribedTreatment);
        }

        public ICommand ShowAppointmentPatientCommand => _showAppointmentPatientCommand
            ??= new LambdaCommand(OnShowAppointmentPatientCommandExecuted, CanShowAppointmentPatientCommandExecte);
        #endregion

        #region RemoveAppointmentCommand - Удаление записи на прием
        private ICommand _removeAppointmentCommand;
        private bool CanRemoveAppointmentCommandExecte(object p) => true;
        private async void OnRemoveAppointmentCommandExecuted(object p)
        {
            var removeAppointment = SelectedAppointment;

            if (!_userDialog.ConfirmWarning($"Вы хотите удалить запись?", "Удаление записи на прием")) return;

            await _accepPatientService.DeleteAppointmentByIdAcync(SelectedAppointment.Id);
            Appointments.Remove(removeAppointment);

            if (ReferenceEquals(SelectedAppointment, removeAppointment))
                SelectedAppointment = null;
        }

        public ICommand RemoveAppointmentCommand => _removeAppointmentCommand
            ??= new LambdaCommand(OnRemoveAppointmentCommandExecuted, CanRemoveAppointmentCommandExecte);

        #endregion

        #endregion
    }
}
