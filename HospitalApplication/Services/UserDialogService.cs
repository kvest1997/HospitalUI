using Hospital.DAL.Entityes;
using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalApplication.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HospitalApplication.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Add(Patient patient)
        {
            var patient_editor_model = new AddPatientViewModel(patient);
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

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;

        public bool OpenAppointment(Appointment appointment, 
            IEnumerable<Diagnosis> diagnoses, 
            IEnumerable<Analysis> analyses, ExaminationResult examinationResult,
            PrescribedTreatment prescribedTreatment)
        {
            var appointment_model = new AppointmentViewModel(appointment, 
                diagnoses, 
                analyses, examinationResult, prescribedTreatment);
            var appointment_window = new AppointmentWindowView
            {
                DataContext = appointment_model
            };

            if (appointment_window.ShowDialog() != true) return false;

            examinationResult.AppointmentId = appointment_model.Appointment.Id;
            examinationResult.DiagnosesId = appointment_model.ExaminationResult.DiagnosesId;
            examinationResult.OutpatientTreatment = appointment_model.ExaminationResult.OutpatientTreatment;
            examinationResult.DisabilityPeriod = appointment_model.ExaminationResult.DisabilityPeriod;
            examinationResult.Dispansary = appointment_model.ExaminationResult.Dispansary;
            examinationResult.Note = appointment_model.ExaminationResult.Note;

            prescribedTreatment.AnalysesId = appointment_model.PrescribedTreatment.AnalysesId;
            prescribedTreatment.Treatment = appointment_model.PrescribedTreatment.Treatment;
            prescribedTreatment.Procedur = appointment_model.PrescribedTreatment.Procedur;
            prescribedTreatment.ExaminationResults = examinationResult;
            prescribedTreatment.ExaminationResultsId = examinationResult.Id;

            return true;
        }

        public bool OpenHistory(IEnumerable<Appointment> appointments)
        {
            var history_model = new PatientHistoryViewModel(appointments);
            var history_window = new PatientHistoryWindowView
            {
                DataContext = history_model
            };

            if (history_window.ShowDialog() != true) return false;

            return true;
        }
    }
}
