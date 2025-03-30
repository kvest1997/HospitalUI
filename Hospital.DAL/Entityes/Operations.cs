using Hospital.DAL.Entityes.Base;
using System;

namespace Hospital.DAL.Entityes
{
    public partial class Operations : Entity
    {
        public Operations()
        {
            
        }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int OperationTypeId { get; set; }
        public OperationTypes OperationType { get; set; }

        public DateTime OperationDate { get; set; }

    }
}
