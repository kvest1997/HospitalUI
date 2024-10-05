using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Specializations : IEntity
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
