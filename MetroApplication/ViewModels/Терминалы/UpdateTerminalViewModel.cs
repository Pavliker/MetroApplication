using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.ViewModels.Терминалы
{
    public class UpdateTerminalViewModel:ViewModelBaseMain, INotifyPropertyChanged
    {

        public RelayCommand MyButtonClickCommandUpdateTerminal { get; set; }
        public IItemsService _itemsservice { get; set; }

        MetroContext dbContext;
        //private ObservableCollection<Models.Терминалы> _Терминалы = new ObservableCollection<Models.Терминалы>();
        public Models.Терминалы ВыбраннаяТерминала;
        //public ObservableCollection<Models.Терминалы> Терминалы
        //{
        //    get
        //    {
        //        return _Терминалы;
        //    }
        //    set
        //    {
        //        _Терминалы = value;
        //    }
        //}
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
        private string _НазваниеТерминала;
        private string НазваниеТерминала
        {
            get
            {
                return _НазваниеТерминала;
            }
            set
            {
                _НазваниеТерминала = value;
                RaisePropertyChanged(nameof(НазваниеТерминала));
            }
        }
        private string? _ЛокальныйАдрес;

        public string? ЛокальныйАдрес
        {
            get => _ЛокальныйАдрес;
            set
            {
                _ЛокальныйАдрес = value;
                RaisePropertyChanged(nameof(ЛокальныйАдрес));
            }
        }

        private string? _МаскаПодсети;
        public string? МаскаПодсети
        {
            get
            {
                return _МаскаПодсети;
            }
            set
            {
                _МаскаПодсети = value;
                RaisePropertyChanged(nameof(МаскаПодсети));

            }
        }

        private string? _адресШлюза;

        public string? АдресШлюза
        {
            get => _адресШлюза;
            set
            {

                _адресШлюза = value;
                RaisePropertyChanged(nameof(АдресШлюза));

            }
        }
        private string? _АдресСервера;

        public string? АдресСервера
        {
            get => _АдресСервера;
            set
            {
           
                _АдресСервера = value;
                RaisePropertyChanged(nameof(АдресСервера));

            }
        }
        private short _ПортХоста;

        public short ПортХоста
        {
            get => _ПортХоста;
            set
            {
                _ПортХоста = value;
                RaisePropertyChanged(nameof(ПортХоста));

            }
        }
        IDialogService dialogs;
        public UpdateTerminalViewModel(Models.Терминалы терминалы, IItemsService items, IDialogService dialogs)
        {
            dbContext = new MetroContext();

            ВыбраннаяТерминала = терминалы;

            _itemsservice = items;
            dialogs = dialogs;
            //Терминалы = new ObservableCollection<Models.Терминалы>((System.Collections.Generic.IEnumerable<Models.Терминалы>)dbContext.Terminals.ToList());

            MyButtonClickCommandUpdateTerminal = new RelayCommand(o => {_itemsservice.UpdateTerminalsMethod(dialogs,выбраннаяТерминалы, КодСтанции, НазваниеТерминала, ЛокальныйАдрес,  МаскаПодсети, АдресШлюза, АдресСервера, ПортХоста);}, o => FuncToEvaluate());

        }



        public bool FuncToEvaluate()
        {
            return выбраннаяТерминалы != null;
        }
  
        public Models.Терминалы выбраннаяТерминалы
        {
            get
            {
                return ВыбраннаяТерминала;
            }
            set
            {
                ВыбраннаяТерминала = value;
                RaisePropertyChanged("выбраннаяТерминалы");
                //MyButtonClickCommandUpdateStation.RaiseCanExecuteChanged();

            }
        }
    }
}
