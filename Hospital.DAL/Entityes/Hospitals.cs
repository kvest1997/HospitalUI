﻿using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель больницы
    /// </summary>
    public partial class Hospitals : Entity
    {
        public Hospitals()
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
