
using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;



namespace MetroApplication.ViewModels.Станции
{
   public class DeleteStationViewModel: ViewModelBaseMain,INotifyPropertyChanged
    {
        public Models.Станции _станции;


        private short кодстанции;
        public short КодСтанции
        {
            get
            {
                return кодстанции;
            }
            set
            {
                кодстанции = value;
                OnPropertyChanged("КодСтанции");
            }
        }

        public RelayCommand ButtonCommandDeleteStation;
        public RelayCommand MyButtonClickCommandDeleteStation
        {
            get
            {
                return ButtonCommandDeleteStation = ButtonCommandDeleteStation ?? new RelayCommand(o => { ItemsService.DeleteStationMethod(dialogs,ССтанции, КодСтанции); }, o => FuncToEvaluate());
            }
        }
        IDialogService dialogs;
      
        public IItemsService ItemsService { get; set; }
        public DeleteStationViewModel(IItemsService _ItemsService , Models.Станции станции, ObservableCollection<Models.Станции>? Станции, IDialogService dialogs)
            
        {
            ItemsService = _ItemsService;
            _станции = станции;

            ItemsService.Станции = Станции;
            this.dialogs = dialogs;
            //КодСтанции = ССтанции?.КодСтанции ?? 0;


        }
        private bool FuncToEvaluate()
        {
            return ССтанции != null;
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
                OnPropertyChanged("ССтанции");
                //MyButtonClickCommandDeleteStation.RaiseCanExecuteChanged();
            }
        }
        
    }
}
