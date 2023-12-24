using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class Hospital
{
    public int HospitalId { get; set; }

    public int NumberHospital { get; set; }

    public string AdressHospital { get; set; } = null!;

    public int NumberPhoneHospital { get; set; }

    public int? StaffId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Staff? Staff { get; set; }
}
