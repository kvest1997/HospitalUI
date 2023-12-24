using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int? SpecializationId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Specialization? Specialization { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
