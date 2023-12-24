using System;
using System.Collections.Generic;

namespace HospitalApplication.Models;

public partial class PrescribedTreatment
{
    public int PrescibedTreatmentId { get; set; }

    public int? AnalysesId { get; set; }

    public int? ExaminationResultsId { get; set; }

    public string? Treatment { get; set; }

    public string? Procedur { get; set; }

    public virtual Analysis? Analyses { get; set; }

    public virtual ExaminationResult? ExaminationResults { get; set; }
}
