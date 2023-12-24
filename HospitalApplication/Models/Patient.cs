using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly Birthday { get; set; }

    public string Adress { get; set; } = null!;

    public int? NumberPhone { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
