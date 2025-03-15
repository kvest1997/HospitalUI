using Hospital.DAL.Entityes.Base;

namespace Hospital.DAL.Entityes
{
    public partial class Operations : Entity
    {
        public Operations()
        {
            
        }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int ExaminationResultId { get; set; }
        public ExaminationResult  ExaminationResult { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string NameOperation { get; set; }
        public string TypeOperation { get; set; }

    }
}
