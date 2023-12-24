using System;
using System.Collections.Generic;

namespace HospitalUIWpfTest;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? HospitalId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly DateAppointment { get; set; }

    public TimeOnly TimeAppointment { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<ExaminationResult> ExaminationResults { get; set; } = new List<ExaminationResult>();

    public virtual Hospital? Hospital { get; set; }

    public virtual Patient? Patient { get; set; }
}
