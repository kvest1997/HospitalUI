using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель персонала
    /// </summary>
    public partial class Staff : Entity
    {
        public Staff()
        {
            Hospitals = new HashSet<Hospitals>();
        }

        public int Id { get; set; }
        public int? NumberDoctor { get; set; }
        public int? DoctorId { get; set; }
        public int? PositionId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Hospitals> Hospitals { get; set; }
    }
}
