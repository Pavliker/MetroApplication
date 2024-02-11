using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.ViewModels.Терминалы
{
   public class AddTerminalViewModel: ViewModelBaseMain
    {
        public RelayCommand ButtonCommandAddTerminal { get; set; }
        public IItemsService _itemsService { get; set; }
        public IDialogService dialogs;
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
        private string? названиетерминала;
        public string? НазваниеТерминала
        {
            get => названиетерминала;
            set
            {
                названиетерминала = value;
                OnPropertyChanged("НазваниеТеримнала");
            }
        }
        private string? локальныйадрес;
        public string? ЛокальныйАдрес
        {
            get => локальныйадрес;
            set
            {
                локальныйадрес = value;
                OnPropertyChanged("ЛокальныйАдрес");
            }
        }
        private string? маскаподсети;
        public string? МаскаПодсети
        {
            get => маскаподсети;
            set
            {
                маскаподсети = value;
                OnPropertyChanged("МаскаПодсети");
            }
        }
        private string? адресшлюза;
        public string? АдресШлюза
        {
            get => адресшлюза;
            set
            {
                адресшлюза = value;
                OnPropertyChanged("АдресШлюза");
            }
        }
        private string? адрессервера;
        public string? АдресСервера
        {
            get => адрессервера;
            set
            {
                адрессервера = value;
                OnPropertyChanged("АдресСервера");
            }
        }
        private short портхоста;
        public short  ПортХоста
        {
            get => портхоста;
            set
            {
                портхоста = value;
                OnPropertyChanged("ПортХоста");
            }
        }

    
        public AddTerminalViewModel(IItemsService itemsservice, IDialogService _dialogs )
        {
            _itemsService = itemsservice;
            dialogs = _dialogs;
            ButtonCommandAddTerminal = new RelayCommand(o => { _itemsService.addTerminals(_dialogs,КодСтанции, НазваниеТерминала, ЛокальныйАдрес, МаскаПодсети, АдресШлюза, АдресСервера, ПортХоста); }, o => true);

        }

    
    }
}
