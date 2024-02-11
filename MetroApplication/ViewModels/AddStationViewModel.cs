
using System.ComponentModel;
using System.Collections.ObjectModel;
using MetroApplication.Services;
using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Views;

namespace MetroApplication.ViewModels
{
    public class AddStationViewModel : ViewModelBaseMain
    {
        public RelayCommand ButtonCommandAddStation { get; set; }
        public IItemsService _itemsService { get; set; }
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
        private string названиестанции;
        public string НазваниеСтанции
        {
            get
            {
                return названиестанции;
            }
            set
            {
                названиестанции = value;
                OnPropertyChanged("НазваниеСтанции");
            }
        }
        private string адрессервера;
        public string АдресСервера
        {
            get
            {
                return адрессервера;
            }
            set
            {
                адрессервера = value;
                OnPropertyChanged("АдресСервера");
            }
        }
        private string шлюз;
        public string Шлюз
        {
            get
            {
                return шлюз;
            }
            set
            {
                шлюз = value;
                OnPropertyChanged("Шлюз");
            }
        }
        private string маска;
        public string Маска
        {
            get
            {
                return маска;
            }
            set
            {
                маска = value;
                OnPropertyChanged("Маска");
            }
        }
        IDialogService dialogs;
        public AddStationViewModel(IItemsService itemsservice,IDialogService dialogs)
        {
            _itemsService = itemsservice;
            this.dialogs = dialogs;
            ButtonCommandAddStation = new RelayCommand(o => { _itemsService.addStations(dialogs,КодСтанции, НазваниеСтанции, АдресСервера, Маска, Шлюз); }, o => true);
        }
    
      
    }
}
