using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Positions : IEntity
    {
        public int Id { get; set ; }
        public string PositionName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
