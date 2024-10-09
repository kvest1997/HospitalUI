using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalUI.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {

        #region Title : string - Заголовок

        /// <summary>Заголовок</summary>
        private string _Title = "Тест окна";

        /// <summary>Заголовок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        public MainWindowViewModel()
        {

        }
    }
}
