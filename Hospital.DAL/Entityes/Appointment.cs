using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public DateTime DateAppointment { get; set; }
        public DateTime TimeAppointment { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public virtual ICollection<ExaminationResults> ExaminationResults { get; set; }
    }
}
