using System;
using System.Collections.ObjectModel;
using MetroApplication.Views;

using System.Windows;
using MetroApplication.Commands;
using MetroApplication.Views.Станции;
using MetroApplication.ViewModels.Станции;
using MetroApplication.Services;

namespace MetroApplication.ViewModels
{
    public class TabControlViewModel:ViewModelBaseMain
    {



        private Models.Станции _станции;
        private Models.Терминалы _терминалы;


        private bool _hideShow;
        public bool hideShow {

            get => _hideShow;
            set
            {
                _hideShow = value;  
                OnPropertyChanged(nameof(hideShow));
            }
        }
        public ViewModels.Станции.UpdateStationViewModel UpdateStationViewModel { get; set; }
        public ViewModels.Терминалы.UpdateTerminalViewModel UpdateTerminalViewModel { get; set; }

        public bool _isRowSelected;

        public bool IsRowSelected
        {
            get { return _isRowSelected; }
            set
            {
                    _isRowSelected = value;
                    OnPropertyChanged(nameof(IsRowSelected));
            }
        }

        private string _PropertySearch;
        public string PropertySearch
        {
            get
            {
                return _PropertySearch;
            }
            set
            {
                _PropertySearch = value;
                OnPropertyChanged(nameof(PropertySearch));
            }
        }

        ObservableCollection<ViewModelBaseMain> _tabcollection;

        IItemsService itemsService { get; set; }

        StationsViewModel StationsViewModel;
        TerminalsViewModel TerminalsViewModel;

        public ObservableCollection<ViewModelBaseMain> TabCollection { get => _tabcollection; }
        private int _selectedTabIndex;

        public RelayCommand FirstWindow { get; set; }
        public RelayCommand SecondWindow { get; set; }
        public RelayCommand ThirdWindow { get; set; }
        public RelayCommand SearchCommand { get; set; }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (value != _selectedTabIndex)
                {
                    _selectedTabIndex = value;
                    OnPropertyChanged("SelectedTabIndex");
                
                }
            }
        }

        IDialogService dialogs;
    

        public TabControlViewModel(IDialogService dialogs,IItemsService itemsService,StationsViewModel stationsViewModel, TerminalsViewModel terminalsViewModel)
        {
            this.dialogs = dialogs;
            StationsViewModel = stationsViewModel;
            TerminalsViewModel = terminalsViewModel;
            _станции = stationsViewModel.ССтанции ?? new();
            _терминалы = terminalsViewModel.ТТерминалы ?? new();
            _tabcollection = new ObservableCollection<ViewModelBaseMain>
            {
                StationsViewModel,
                TerminalsViewModel
            };
            SelectedTabIndex = 0;
            hideShow = true;

            this.itemsService = itemsService;
        


            StationsViewModel.FuncToEvulateRequested += StationsViewModel_FuncToEvulateRequested;

            TerminalsViewModel.FuncToEvulateRequested1 += StationsViewModel_FuncToEvulateRequested1;

            FirstWindow = new RelayCommand(o => { NavigateToAddStationOrTerminal(); }, o => true);

             SecondWindow = new RelayCommand(o => { NavigateToEditStationOrTerminal(); }, o => IsRowSelected);
            ThirdWindow = new RelayCommand(o => { NavigateToDeleteStationOrTerminal(); }, o => IsRowSelected);

            SearchCommand = new RelayCommand(o => { SearchCommandStationOrTerminal(); }, o=>true);
       

    }
     private string _названиеТерминала;
           public string НазваниеТерминала
        {

            get
            {
                return _названиеТерминала;
            }
            set
            {
            _названиеТерминала = value;
                OnPropertyChanged(nameof(НазваниеТерминала));
            }
        }

        public void SearchCommandStationOrTerminal()
        {
            if (SelectedTabIndex == 0)
            {
                return;
            }
            else
            {
                itemsService.SearchTerminal(dialogs,НазваниеТерминала);
            }
        }
        private void StationsViewModel_FuncToEvulateRequested(object sender, EventArgs e)
        {
            if (StationsViewModel.ССтанции != null )
            {
                IsRowSelected = StationsViewModel.FuncToEvulate();


            }
            else
            {
                IsRowSelected = false;
            }

        }
        private void StationsViewModel_FuncToEvulateRequested1(object sender, EventArgs e)
        {
            if (TerminalsViewModel.ТТерминалы != null)
            {

                IsRowSelected = TerminalsViewModel.FuncToEvulate();

            }
            else
            {
                IsRowSelected = false;
            }

        }
        //public bool HandleDataGridSelectionChanged()
        //{
        //    IsRowSelected = (dataGrid.SelectedItems.Count > 0);
        //}

        //public void Load()
        //{

        //    if (_tabcollection != null)
        //    {

        //            //StationsViewModel = new StationsViewModel();
        //            _tabcollection.Add(StationsViewModel);
        //            //TerminalsViewModel = new TerminalsViewModel();  
        //            _tabcollection.Add(TerminalsViewModel);
        //        hideShow =false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Having data");
        //    }
        //}
    

        public void NavigateToAddStationOrTerminal()
        {

            if (SelectedTabIndex == 0)
            {
                StationsViewModel.Show();

            }

            else if (SelectedTabIndex == 1)
            {
                
                    TerminalsViewModel.Show();
                
            }
        }

        public void NavigateToEditStationOrTerminal()
        {
            if (SelectedTabIndex == 0)
            {
                StationsViewModel.Show1();

            }
       
            else if (SelectedTabIndex == 1)
            {
                if (TerminalsViewModel != null)
                {
                    TerminalsViewModel.Show1();
                }
            }
        }
        public void NavigateToDeleteStationOrTerminal()
        {
            if (SelectedTabIndex == 0)
            {

                StationsViewModel.Show2();  

            }
            if (SelectedTabIndex == 1)
            {

                TerminalsViewModel.Show2();

            }
        }

        public Models.Станции ССтанции
        {
            get => _станции;
            set
            {
                _станции = value;
                //SecondWindow.RaiseCanExecuteChanged();
                RaisePropertyChanged(nameof(ССтанции));
   
            }
        }

    }
}
