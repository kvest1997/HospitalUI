using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class PrescribedTreatment : IEntity
    {
        public int Id { get; set; }
        public string Treatment { get; set; }
        public string Procedur { get; set; }

        public int AnalysesId { get; set; }
        public virtual Analyses Analyses { get; set; }

        public int ExaminationResultId { get; set; }
        public virtual ExaminationResults ExaminationResults { get; set; }
    }
}
