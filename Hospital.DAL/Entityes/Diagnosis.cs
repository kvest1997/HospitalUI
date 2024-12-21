using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hospital.DAL.Entityes
{
    /// <summary>
    /// Модель диагнозов
    /// </summary>
    public partial class Diagnosis : Entity
    {
        public Diagnosis()
        {
            ExaminationResults = new HashSet<ExaminationResult>();
        }

        public string DiagnosesName { get; set; }
        public string DiagnosesBlock { get; set; }
        public string DiagnosesClass { get; set; }

        public virtual ICollection<ExaminationResult> ExaminationResults { get; set; }
    }
}
