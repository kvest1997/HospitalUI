using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class Analysis
{
    public int AnalysesId { get; set; }

    public string? AnalysesName { get; set; }

    public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; } = new List<PrescribedTreatment>();
}
