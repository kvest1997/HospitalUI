﻿using System;
using System.Collections.Generic;

namespace HospitalUIWpfTest;

public partial class Position
{
    public int PositionId { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
