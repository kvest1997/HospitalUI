using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Hospital : Entity
    {
        public Hospital()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int NumberHospital { get; set; }
        public string AdressHospital { get; set; }
        public int NumberPhoneHospital { get; set; }
        public int? StaffId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
