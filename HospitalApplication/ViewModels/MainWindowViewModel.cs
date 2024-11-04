using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalUI.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

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
        }

        #region Property
        public IList<Patient> Patients
        {
            get
            {
                return GetPatients();
            }
        }
        #endregion

        #region Methods
        private List<Patient> GetPatients()
        {
            return _patients.Items.Take(10).ToList();
        }

        #endregion
    }
}
