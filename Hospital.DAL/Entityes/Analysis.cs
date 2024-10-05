using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Analysis : IEntity
    {
        public Analysis()
        {
            PrescribedTreatments = new HashSet<PrescribedTreatment>();
        }

        public int Id { get; set; }
        public string AnalysesName { get; set; }

        public virtual ICollection<PrescribedTreatment> PrescribedTreatments { get; set; }
    }
}
