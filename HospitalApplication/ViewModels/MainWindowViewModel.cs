using Hospital.DAL.Entityes;
using Hospital.Interfaces;
using HospitalUI.ViewModels.Base;
using MathCore.Values;
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
        private readonly IRepository<Book> _BooksRepository;

        #region Title : string - Заголовок

        /// <summary>Заголовок</summary>
        private string _Title = "Тест окна";

        /// <summary>Заголовок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        public MainWindowViewModel(IRepository<Book> BooksRepository)
        {
            _BooksRepository = BooksRepository;

            var books = BooksRepository.Items.Take(10).ToArray();
        }
    }
}
