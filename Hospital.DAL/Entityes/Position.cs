using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель позиции
    /// </summary>
    public partial class Position : Entity
    {
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        public string PositionName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
