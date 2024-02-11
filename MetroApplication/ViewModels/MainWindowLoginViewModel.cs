using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using MetroApplication.Commands;
using MetroApplication.Services;
using MetroApplication.ViewModels;
using MetroApplication.Views;

namespace MetroApplication.ViewModels
{
  public class MainWindowLoginViewModel:ViewModelBaseMain
    {
        private bool enable;
        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
            }
        }

        private object _currentView; 
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }
        public RelayCommand NavigateToAuthOP { get; set; }

        public INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged("Navigation");
            }
        }
       
        public IWindowManager windowManager;
        public IItemsService _items;
        public IDialogService dialogService;    
        public MainWindowLoginViewModel(INavigationService navService,IWindowManager windows, IItemsService items, IDialogService dialogs)
        {
            enable = true;
            Navigation = navService;
            windowManager = windows;
            _items = items;
            dialogService = dialogs;
           
            NavigateToAuthOP = new RelayCommand(o =>{ NavigateToAuthOPCommandExecute();}, o => FuncToEvaluate());

        }
        public bool FuncToEvaluate()
        {
            return Navigation.CurrentView == null;
        }
        private void NavigateToAuthOPCommandExecute()
        {
            CurrentView = new Auth() {DataContext = new AuthOPViewModel(this,Navigation, windowManager,_items,dialogService) };
            enable = false;
        }

    }
}
