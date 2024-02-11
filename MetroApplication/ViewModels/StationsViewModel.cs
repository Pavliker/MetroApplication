
using MetroApplication.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using MetroApplication.Views;
using MetroApplication.ViewModels.Станции;
using MetroApplication.Views.Станции;
using MetroApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MetroApplication.ViewModels
{
    public class StationsViewModel : ViewModelBaseMain
    {
        public IWindowManager _iwindowmanager;
        AddStationViewModel add;
        DeleteStationViewModel del;
        UpdateStationViewModel update;
        MetroContext dbContext;
        public Models.Станции _станции;
       
        private string? _tabName;
        private  IItemsService _ItemsService;
        public IItemsService ItemsService
        {
            get => _ItemsService;
            set
            {


                _ItemsService = value;
                OnPropertyChanged(nameof(ItemsService));
            }
        }
        IDialogService dialogs;
        public StationsViewModel(IWindowManager iwindowmanager, IItemsService _ItemsService, IDialogService dialogs)
        {
            ItemsService = _ItemsService;
            dbContext = new MetroContext();
            TabName = "Станции";
            ItemsService.Станции = new ObservableCollection<Models.Станции>(dbContext.Stations.ToList());
            _iwindowmanager = iwindowmanager;
            this.dialogs = dialogs;
        }
        public void Show()
        {
            add = new AddStationViewModel(ItemsService,dialogs);
            _iwindowmanager.ShowWindow(add);
        }
        public void Show1() 
        {
            update = new UpdateStationViewModel(dialogs, ItemsService, ССтанции);
            _iwindowmanager.ShowWindow(update);
        }  

        public void Show2() 
        {
            del = new DeleteStationViewModel(ItemsService, ССтанции, ItemsService.Станции, dialogs);
            _iwindowmanager.ShowWindow(del);
        } 
    
        public string? TabName
        {
            get { return _tabName; }
            set
            {
                if (_tabName != value)
                {
                    _tabName = value;
                    RaisePropertyChanged(nameof(TabName));
                }
            }
        }
        public event EventHandler FuncToEvulateRequested;
    
 
        private void OnFuncToEvulateRequested()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                FuncToEvulateRequested?.Invoke(this, EventArgs.Empty);
            });
        }
        public Models.Станции ССтанции
        {
            get
            {
                return _станции;
            }
            set
            {
                _станции = value;
                RaisePropertyChanged("ССтанции");
                OnFuncToEvulateRequested();
            }
        }
        public bool FuncToEvulate()
        {
            return ССтанции != null || ССтанции == null;
        }
    }
}
