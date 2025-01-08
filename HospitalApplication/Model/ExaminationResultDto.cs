using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    internal class ExaminationResultDto : ViewModel
    {
        private int? _diagnosesId;
        private string _outpatientTreatment;
        private DateTime? _disabilityPeriod;
        private bool? _dispansary;
        private string _note;

        public ExaminationResultDto() { }
        public ExaminationResultDto(int? diagnosesId, string outpatientTreatment, DateTime? disabilityPeriod, bool? dispansary, string note)
        {
            _diagnosesId = diagnosesId;
            _outpatientTreatment = outpatientTreatment;
            _disabilityPeriod = disabilityPeriod;
            _dispansary = dispansary;
            _note = note;
        }

        public int? DiagnosesId { get => _diagnosesId; set => Set(ref _diagnosesId, value); }
        public string OutpatientTreatment { get => _outpatientTreatment; set => Set(ref _outpatientTreatment, value); }
        public DateTime? DisabilityPeriod { get => _disabilityPeriod; set => Set(ref _disabilityPeriod, value); }
        public bool? Dispansary { get => _dispansary; set => Set(ref _dispansary, value); }
        public string Note { get => _note; set => Set(ref _note, value); }
    }
}
