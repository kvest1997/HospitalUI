﻿using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HospitalApplication.ViewModels
{
    internal class AcceptPatientViewModel : ViewModel
    {
        private readonly IAccepPatientService _accepPatientService;

        private ObservableCollection<Appointment> _appointments;
        private Appointment _selectedAppointment;

        private DateTime _fromDate = DateTime.Now;
        private DateTime _toDate = DateTime.Now;

        public AcceptPatientViewModel(IAccepPatientService accepPatientService) 
        {
            _accepPatientService = accepPatientService;
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

        #endregion
    }
}
