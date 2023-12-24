using System;
using System.Collections.Generic;

namespace HospitalUIWpfTest;

public partial class Diagnosis
{
    public int DiagnosesId { get; set; }

    public string? DiagnosesName { get; set; }

    public string? DiagnosesBlock { get; set; }

    public string? DiagnosesClass { get; set; }

    public virtual ICollection<ExaminationResult> ExaminationResults { get; set; } = new List<ExaminationResult>();
}
