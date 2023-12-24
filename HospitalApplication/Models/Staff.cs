using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? NumberDoctor { get; set; }

    public int? DoctorId { get; set; }

    public int? PositionId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

    public virtual Position? Position { get; set; }
}
