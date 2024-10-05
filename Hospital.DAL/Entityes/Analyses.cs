using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Analyses : IEntity
    {
        public int Id { get; set; }

        public string AnalysesName { get; set; }

        public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; }
    }
}
