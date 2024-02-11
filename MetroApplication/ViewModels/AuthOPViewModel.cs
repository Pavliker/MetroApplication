using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;

using System;

using MetroApplication.ViewModels;
using System.Windows.Data;
using MetroApplication.Views;
using System.Security;
using System.Windows.Controls;
using System.Windows;

namespace MetroApplication.ViewModels
{
    public class AuthOPViewModel : ViewModelBaseMain
    {
        //Variables
        private MessageBoxViewModel MessageBoxViewModel;
        private MainWindowLoginViewModel MainWindowLoginViewModel;
        public MainWindowLoginViewModel _mainWindowViewModel;
        public IWindowManager WindowManager;
        IAuthService AuthService;
        IDialogService _dialog;
        MetroContext _dbContext = new MetroContext();
        MainWindowViewModel mainWindow;
        //Properties
        private string text = "Зарегистрироваться в качестве работника";
        public string Text
        {
            get => text;
            set => text = value;
        }
        private string Auth;
        public string reg
        {
            get { return Auth; }    
            set=> Auth = value;
        }
        private string _Логин;
        public string Логин
        {
            get => _Логин;
            set
            {
                _Логин = value;
                OnPropertyChanged(nameof(Логин));
            }
        }
        private SecureString _Пароль;
        public SecureString Пароль
        {
            private get => _Пароль;
            set
            {
                _Пароль = value;
                OnPropertyChanged(nameof(Пароль));
            }
        }
        public IItemsService itemsService { get; set; }
        INavigationService navService;
        public INavigationService Navigation
        {
            get => navService;
            set
            {
                navService = value;
                OnPropertyChanged("Navigation");
            }
        }

        public RelayCommand NavigateToRegU { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public AuthOPViewModel(MainWindowLoginViewModel mainWindowViewModel, INavigationService navigation, IWindowManager windows, IItemsService items, IDialogService dialogs)
        {
            reg = "Войти"; 
            _mainWindowViewModel = mainWindowViewModel;
            AuthService = new AuthService(_dbContext);
            LoginCommand = new RelayCommand(o => { LoginMethod(); }, o => true);
            NavigateToRegU = new RelayCommand(o => { NavigateToRegUCommandExecute(); }, o => FuncToEvaluate());
            Navigation = navigation;
            WindowManager = windows;
            itemsService = items;
            _dialog = dialogs;
        }
        public void LoginMethod()
        {
            try
            {
                Работники loggedInWorker = GetLoggedInWorker();
                Операторы loggedInOperator = GetLoggedInOperator();
              
                if (loggedInWorker != null || loggedInOperator != null)
                {
                    mainWindow = new MainWindowViewModel(Navigation);
                    MainWindowLoginViewModel = new MainWindowLoginViewModel(Navigation, WindowManager, itemsService, _dialog);
                    if (loggedInOperator!=null)
                    {
                        AuthService.AssignRoleToOperator(loggedInOperator, "Оператор");
                        WindowManager.ShowWindow(mainWindow);
                        WindowManager.CloseWindow(MainWindowLoginViewModel);
                    }
                    else if (loggedInWorker != null)
                    {
                        // Проверяем, успешно ли аутентифицирован пользователь
                        if (loggedInWorker!= null)
                        {
                            WindowManager.ShowWindow(mainWindow);
                            WindowManager.CloseWindow(MainWindowLoginViewModel);
                        }
                        else
                        {
                            MessageBoxViewModel = new MessageBoxViewModel(_dialog, "Ошибка аутентификации");
                            MessageBoxViewModel.Show();
                        }
                    }
                }
                else
                {
                    MessageBoxViewModel = new MessageBoxViewModel(_dialog, "Похоже данного аккаунта нету)");
                    MessageBoxViewModel.Show();
                }
            }
            catch (Exception e)
            {
                itemsService.ErrorMessage = e.Message;
            }
        }
        private Операторы GetLoggedInOperator()
        {
            var operatorId = AuthService.AuthenticateOperator(Логин, Пароль);
                if (operatorId.HasValue)
                {
                   Операторы loggedInOperator = _dbContext.Operators.Find(operatorId.Value);
                return loggedInOperator;
            }
            return null;
        }
        private Работники GetLoggedInWorker()
        {
            int? userId = AuthService.AuthenticateWorker(Логин, Пароль);
            if (userId.HasValue)
            {
                Работники loggedInUser = _dbContext.Workers.Find(userId.Value);
                return loggedInUser;
            }

            return null;
        }
        public bool FuncToEvaluate()
        {
            return Navigation.CurrentView == null;
        }
        private void NavigateToRegUCommandExecute()
        {
         _mainWindowViewModel.CurrentView = new RegU() { DataContext = new RegUViewModel( itemsService, _dialog) };
        }
    }
}
