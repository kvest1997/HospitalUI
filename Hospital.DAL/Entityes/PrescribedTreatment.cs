using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class PrescribedTreatment : Entity
    {
        public int? AnalysesId { get; set; }
        public int? ExaminationResultsId { get; set; }
        public string Treatment { get; set; }
        public string Procedur { get; set; }

        public virtual Analysis Analyses { get; set; }
        public virtual ExaminationResult ExaminationResults { get; set; }
    }
}
