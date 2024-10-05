using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Staff : IEntity
    {
        public int Id { get; set; }

        public int NumberDoctor { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int PositionId { get; set; }
        public virtual Positions Position { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }

    }
}
