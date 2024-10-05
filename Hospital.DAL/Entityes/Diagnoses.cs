using Hospital.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entityes
{
    public class Diagnoses : IEntity
    {
        public int Id { get; set; }

        public string DiagnosesName { get; set; }
        public string DiagnosesBlock { get; set; }
        public string DiagnosesClass { get; set; }

        public virtual ICollection<ExaminationResults> ExaminationResults { get; set; }
    }
}
