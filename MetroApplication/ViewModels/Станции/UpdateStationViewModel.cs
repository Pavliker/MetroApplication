
using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;

namespace MetroApplication.ViewModels.Станции
{
    public class UpdateStationViewModel : ViewModelBaseMain, INotifyPropertyChanged
    {

        private ObservableCollection<Models.Станции> _Станции = new ObservableCollection<Models.Станции>();

        public Models.Станции ВыбраннаяСтанция;
        public ObservableCollection<Models.Станции> Станции 
        { 
            get 
            { 
                return _Станции;
            } 
            set
            {
                _Станции = value;
            }
        }

        private short _КодСтанции;
        private short КодСтанции
        {
            get
            {
                return _КодСтанции;
            }
            set
            {
                _КодСтанции = value;
                RaisePropertyChanged(nameof(КодСтанции));
            }
        }


        private string _НазваниеСтанции;
        private  string НазваниеСтанции
        {
            get
            {
                return _НазваниеСтанции;
            }
            set
            {
                _НазваниеСтанции = value;
                RaisePropertyChanged(nameof(НазваниеСтанции));
            }
        }
        private string _АдресСервера;
        private string АдресСервера

        {
            get
            {
                return _АдресСервера;
            }
            set
            {
                _НазваниеСтанции = value;
                RaisePropertyChanged(nameof(АдресСервера));
            }
        }
        private string _Шлюз;
        private string Шлюз

        {
            get
            {
                return _Шлюз;
            }
            set
            {
                _Шлюз = value;
                RaisePropertyChanged(nameof(Шлюз));
            }
        }
        private string _Маска;
        private string Маска

        {
            get
            {
                return _Маска;
            }
            set
            {
                _Маска = value;
                RaisePropertyChanged(nameof(Маска));
            }
        }
        IItemsService itemsservice { get; set; }

        IDialogService dialogs;

        public RelayCommand ButtonCommandUpdateStation;
        public RelayCommand MyButtonClickCommandUpdateStation
        {
            get
            {
                return ButtonCommandUpdateStation =
                    ButtonCommandUpdateStation ?? new RelayCommand(o=> { itemsservice.updateStation(dialogs,выбраннаяСтанции, НазваниеСтанции,АдресСервера, Маска,Шлюз); }, o=> true);
            }
        }
        public UpdateStationViewModel(IDialogService dialogs,IItemsService items,Models.Станции станции)
        {
            itemsservice = items;
            ВыбраннаяСтанция = станции;
            this.dialogs = dialogs;
        }
        public Models.Станции выбраннаяСтанции
        {
            get
            {
                return ВыбраннаяСтанция;
            }
            set
            {
                ВыбраннаяСтанция = value;
                RaisePropertyChanged("выбраннаяСтанции");
            }
        } 
        

    }
}
