using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalApplication.Views;

namespace HospitalApplication.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Patient patient)
        {
            var patient_editor_model = new AddPatientViewModel(patient);
            var patient_editor_window = new AddPatientWindow
            {
                DataContext = patient_editor_model
            };

            if (patient_editor_window.ShowDialog() != true) return false;

            return true;
        }
    }
}
