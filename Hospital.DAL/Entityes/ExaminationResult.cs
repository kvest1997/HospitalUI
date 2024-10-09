using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class ExaminationResult : Entity
    {
        public ExaminationResult()
        {
            PrescribedTreatments = new HashSet<PrescribedTreatment>();
        }

        public int? AppointmentId { get; set; }
        public int? DiagnosesId { get; set; }
        public string OutpatientTreatment { get; set; }
        public DateTime? DisabilityPeriod { get; set; }
        public bool? Dispansary { get; set; }
        public string Note { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Diagnosis Diagnoses { get; set; }
        public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; }
    }
}
