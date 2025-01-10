using HospitalUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    internal class PrescribedTreatmentDto : ViewModel
    {
        private int? _analysesId;
        private int? _examinationResultsId;
        private string _treatment;
        private string _procedur;

        public PrescribedTreatmentDto() { }

        public PrescribedTreatmentDto(int? analysesId, int? examinationResultId, string treatment, string procedur)
        {
            _analysesId = analysesId;
            _examinationResultsId = examinationResultId;
            _treatment = treatment;
            _procedur = procedur;
        }

        public int? AnalysesId { get => _analysesId; set => Set(ref _analysesId, value); }
        public int? ExaminationResultsId { get => _examinationResultsId; set => Set(ref _examinationResultsId, value); }
        public string Treatment { get => _treatment; set => Set(ref _treatment, value); }
        public string Procedur { get => _procedur; set => Set(ref _procedur, value); }
    }
}
