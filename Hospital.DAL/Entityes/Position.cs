﻿using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Position : IEntity
    {
        public Position()
        {
            staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Staff> staff { get; set; }
    }
}
