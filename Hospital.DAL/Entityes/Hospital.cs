using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Hospital : IEntity
    {
        public int Id { get; set; }

        public int NumberHospital { get; set; }
        public string AdressHospital { get; set; }
        public int NumberPhoneHospital { get; set; }

        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
