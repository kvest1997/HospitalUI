using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Doctor : IEntity
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
