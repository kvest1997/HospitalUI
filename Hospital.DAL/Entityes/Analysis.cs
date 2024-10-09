using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Analysis : Entity
    {
        public Analysis()
        {
            PrescribedTreatments = new HashSet<PrescribedTreatment>();
        }

        public string AnalysesName { get; set; }

        public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; }
    }
}
