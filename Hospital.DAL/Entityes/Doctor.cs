using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SpecializationId { get; set; }
        public virtual Specializations Specializations { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
