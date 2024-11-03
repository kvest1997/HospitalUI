using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalUI.ViewModels.Base;
using System.Linq;

namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Patient> _patients;

        #region Title : string - Заголовок

        /// <summary>Заголовок</summary>
        private string _Title = "Тест окна";

        /// <summary>Заголовок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        public MainWindowViewModel(IRepository<Patient> Patients)
        {
            _patients = Patients;

            var pat = _patients.Items.Take(5).ToList();
        }

        #region Property

        #endregion
    }
}
