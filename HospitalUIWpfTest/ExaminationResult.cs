using System;
using System.Collections.Generic;

namespace HospitalUIWpfTest;

public partial class ExaminationResult
{
    public int ExaminationResultsId { get; set; }

    public int? AppointmentId { get; set; }

    public int? DiagnosesId { get; set; }

    public string? OutpatientTreatment { get; set; }

    public DateOnly? DisabilityPeriod { get; set; }

    public bool? Dispansary { get; set; }

    public string? Note { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Diagnosis? Diagnoses { get; set; }

    public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; } = new List<PrescribedTreatment>();
}
