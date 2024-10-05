using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Patient : IEntity
    {
        public int Id { get; set; }

        public string SeconName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public int NumberPhone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
