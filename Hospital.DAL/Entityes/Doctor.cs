using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель Доктора
    /// </summary>
    public partial class Doctor : Entity
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Staff = new HashSet<Staff>();
            Operations = new HashSet<Operations>();
        }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }

        public string FullName => $"{SecondName} {FirstName} {LastName}";
    }
}
