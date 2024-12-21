using HospitalApplication.Services.Interfaces;
using HospitalApplication.ViewModels;
using HospitalUI.Infrastructure.Commands;
using HospitalUI.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;


namespace HospitalUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {        
        private readonly IServiceProvider _serviceProvider;
        private readonly IRegistoryPatientService _patientService;
        private readonly IUserDialog _userDialog;
        private readonly IAccepPatientService _accepPatientService;

        private ViewModel _currentViewModel;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _patientService = GetRegitoryPatientService();
            _userDialog = GetUserDialogService();
            _accepPatientService = GetAccepPatientService();
        }

        #region Commands

        #region OpenPatientsGridCommand - Отображение всех пациентов
        private ICommand _openPatientsGridCommand;
        private bool CanOpenPatientsGridCommandExecte(object p) => true;
        private void OnOpenPatientsGridCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientsViewModel(_patientService, _userDialog);
        }
        public ICommand OpenPatientsGridCommand => _openPatientsGridCommand
            ??= new LambdaCommand(OnOpenPatientsGridCommandExecuted, CanOpenPatientsGridCommandExecte);
        #endregion

        #region ShowPatientRegistrationViewCommand - Отображение регистрации пациента на приеме
        private ICommand _showPatientRegistrationViewCommand;
        private bool CanShowPatientRegistrationViewCommandExecte(object p) => true;
        private void OnShowPatientRegistrationViewCommandExecuted(object p) 
        {
            CurrentViewModel = new PatientRegistrationViewModel(_patientService);
        }
        public ICommand ShowPatientRegistrationViewCommand => _showPatientRegistrationViewCommand
            ??= new LambdaCommand(OnShowPatientRegistrationViewCommandExecuted, CanShowPatientRegistrationViewCommandExecte);
        #endregion

        #region CloseCommand - Закрытие приложения
        private ICommand _closeCommand;
        private bool CanCloseCommandExecte(object p) => true;
        private void OnCloseCommandExecuted(object p)
        {
            CloseApplicationCommand closeApplicationCommand = new CloseApplicationCommand();
            closeApplicationCommand.Execute(p);
        }
        public ICommand CloseCommand => _closeCommand
            ??= new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecte);
        #endregion

        #region ShowAcceptPatientViewCommand - Отображать записи пациентов
        private ICommand _showAcceptPatientViewCommand;
        private bool CanShowAcceptPatientViewCommandExecte(object p) => true;
        private void OnShowAcceptPatientViewCommandExecuted(object p)
        {
            CurrentViewModel = new AcceptPatientViewModel(_accepPatientService);
        }
        public ICommand ShowAcceptPatientViewCommand => _showAcceptPatientViewCommand
            ??= new LambdaCommand(OnShowAcceptPatientViewCommandExecuted, CanShowAcceptPatientViewCommandExecte);
        #endregion

        #endregion

        #region Property
        /// <summary>
        /// Текущая дочерняя модель-представления
        /// </summary>
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => Set(ref _currentViewModel, value);
        }
        #endregion

        #region Methods

        private IAccepPatientService GetAccepPatientService() => _serviceProvider.GetRequiredService<IAccepPatientService>();

        private IRegistoryPatientService GetRegitoryPatientService() => _serviceProvider.GetRequiredService<IRegistoryPatientService>();

        private IUserDialog GetUserDialogService() => _serviceProvider.GetRequiredService<IUserDialog>();
        #endregion
    }
}
