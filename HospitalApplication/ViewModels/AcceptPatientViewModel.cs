using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalUI.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HospitalApplication.ViewModels
{
    internal class AcceptPatientViewModel : ViewModel
    {
        private readonly IAccepPatientService _accepPatientService;

        private ObservableCollection<Appointment> _appointments;
        private Appointment _selectedAppointment;

        public AcceptPatientViewModel(IAccepPatientService accepPatientService) 
        {
            _accepPatientService = accepPatientService;
            InitializeDateAsync();
        }

        #region Propertys

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
            Appointments = new ObservableCollection<Appointment>(await _accepPatientService.GetAppointmentsAsync());
        }
        #endregion

        #region Commands
        #endregion
    }
}
