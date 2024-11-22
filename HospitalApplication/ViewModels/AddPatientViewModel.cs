using Hospital.DAL.Entityes;
using HospitalUI.ViewModels.Base;

namespace HospitalApplication.ViewModels
{
    class AddPatientViewModel : ViewModel
    {
        public AddPatientViewModel()
        {

        }

        private string _secondName;
        public string SecondName
        {
            get => _secondName;
            set => Set(ref _secondName, value);
        }

        private string _firstName;
        public string FirstName 
        {
            get => _firstName;
            set => Set(ref _firstName, value); 
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        private string _bDay;
        public string BDay 
        { 
            get => _bDay; 
            set => Set(ref _bDay, value); 
        }

        private string _adress;
        public string Adress 
        { 
            get => _adress; 
            set => Set(ref _adress, value); 
        }

        private string _numberPhone;
        public string NumberPhone 
        { 
            get => _numberPhone; 
            set => Set(ref _numberPhone, value); 
        }
    }
}
