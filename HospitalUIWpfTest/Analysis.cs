using System;
using System.Collections.Generic;

namespace HospitalUIWpfTest;

public partial class Analysis
{
    public int AnalysesId { get; set; }

    public string? AnalysesName { get; set; }

    public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; } = new List<PrescribedTreatment>();
}
