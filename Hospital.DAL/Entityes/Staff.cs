using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Staff : IEntity
    {
        public Staff()
        {
            Hospitals = new HashSet<Hospital>();
        }

        public int Id { get; set; }
        public int? NumberDoctor { get; set; }
        public int? DoctorId { get; set; }
        public int? PositionId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}
