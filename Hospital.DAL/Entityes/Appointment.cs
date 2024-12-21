using Hospital.DAL.Entityes.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель записи на прием
    /// </summary>
    public partial class Appointment : Entity
    {
        public Appointment()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int? PatientId { get; set; }
        public int? HospitalId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeAppointment { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Hospitals Hospital { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
