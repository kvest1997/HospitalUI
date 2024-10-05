using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    public partial class Diagnosis : IEntity
    {
        public Diagnosis()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public int Id { get; set; }
        public string DiagnosesName { get; set; }
        public string DiagnosesBlock { get; set; }
        public string DiagnosesClass { get; set; }

        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
