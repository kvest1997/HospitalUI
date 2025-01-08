using Hospital.DAL.Entityes;
using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.ViewModels
{
    internal class AppointmentViewModel : ViewModel
    {
        private Appointment _appointment;

        public AppointmentViewModel(Appointment appointment)
        {
            _appointment = appointment;
        }

        #region Property
        public Appointment Appointment
        {
            get => _appointment;
            set => Set(ref _appointment, value);
        }
        #endregion

        #region Methods

        #endregion

        #region Commands

        #endregion
    }
}
