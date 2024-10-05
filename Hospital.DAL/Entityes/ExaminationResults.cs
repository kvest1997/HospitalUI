using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class ExaminationResults : IEntity
    {
        public int Id { get; set; }

        public string OutpatientTreatment { get; set; }
        public DateTime DisabilityPeriod { get; set; }
        public bool Dispansary { get; set; }
        public string Note { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public int DiagnosesId { get; set; }
        public virtual Diagnoses Diagnoses { get; set; }


        public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; }
    }
}
