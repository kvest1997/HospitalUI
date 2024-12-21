using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель специализации доктора
    /// </summary>
    public partial class Specialization : Entity
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
