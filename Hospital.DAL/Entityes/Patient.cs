using Hospital.DAL.Entityes.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель пациента
    /// </summary>
    public partial class Patient : Entity
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Operations = new HashSet<Operations>();
        }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public int? NumberPhone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }

        public string FullName => $"{SecondName} {FirstName} {LastName}";
    }
}
