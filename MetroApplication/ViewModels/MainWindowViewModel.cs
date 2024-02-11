using System.Windows.Input;
using MetroApplication.Views;
using MetroApplication.Services;
using MetroApplication.Commands;
using MetroApplication.ViewModels.Станции;
using System.Windows.Controls;
using System.Windows;
using MetroApplication.ViewModels.Отчёты;

namespace MetroApplication.ViewModels
{
    public class MainWindowViewModel : ViewModelBaseMain
    {
        public string tables { get; set; }
        //private FrameworkElement? _contentControlView;
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
        public ICommand NavigateToTables { get; set; }
        public ICommand NavigateToArchive { get; set; }
        public ICommand NavigateToTerminalsAndStations { get; set; }
        public ICommand NavigateToSchemOfMetro { get; set; }
        public ICommand NavigateToReports { get; set; }

        public MainWindowViewModel(INavigationService navService)
        {
            Navigation = navService;
            tables = "Таблицы";
            NavigateToTables = new RelayCommand(o => Navigation.NavigateTo<TabControlViewModel>(), o => FuncToEvaluate());
            NavigateToArchive = new RelayCommand(o=>Navigation.NavigateTo<ArchiveOfSettingsViewModel>(), o=> FuncToEvaluate());
            NavigateToTerminalsAndStations = new RelayCommand(o => Navigation.NavigateTo<TerminalsAndStationsViewModel>(), o => FuncToEvaluate());
            NavigateToSchemOfMetro = new RelayCommand(o=> Navigation.NavigateTo<SchemOfMetroViewModel>(), o => FuncToEvaluate());
            NavigateToReports  = new RelayCommand(o => Navigation.NavigateTo<ReportsViewModel>(), o => FuncToEvaluate());

        }
        private bool FuncToEvaluate()
        {
            return Navigation.CurrentView == null || Navigation.CurrentView!=null;
        }
    }
}
