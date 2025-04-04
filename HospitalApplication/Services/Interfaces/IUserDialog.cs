﻿using Hospital.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalApplication.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool OpenHistory(IEnumerable<Appointment> appointments);

        bool Add(Patient patient);

        bool ConfirmWarning(string Warning, string Caption);

        bool OpenAppointment(Appointment appointment, 
            IEnumerable<Diagnosis> diagnoses, 
            IEnumerable<Analysis> analyses, ExaminationResult examinationResult,
            PrescribedTreatment prescribedTreatment);
    }
}
