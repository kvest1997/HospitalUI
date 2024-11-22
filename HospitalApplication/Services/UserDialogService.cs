using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalApplication.Views;
using System;

namespace HospitalApplication.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Add(Patient patient)
        {
            var patient_editor_model = new AddPatientViewModel();
            var patient_editor_window = new AddPatientWindow
            {
                DataContext = patient_editor_model
            };

            if (patient_editor_window.ShowDialog() != true) return false;

            patient.SecondName = patient_editor_model.SecondName; 
            patient.FirstName = patient_editor_model.FirstName;
            patient.LastName = patient_editor_model.LastName;
            patient.Adress = patient_editor_model.Adress;
            patient.Birthday = DateTime.Parse(patient_editor_model.BDay);
            patient.NumberPhone = int.Parse(patient_editor_model.NumberPhone);

            return true;
        }
    }
}
