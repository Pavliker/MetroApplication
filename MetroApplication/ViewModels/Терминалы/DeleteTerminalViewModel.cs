using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using MetroApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.ViewModels.Терминалы
{
    public class DeleteTerminalViewModel:ViewModelBaseMain
    {
        public IItemsService ItemsService { get; set; }
        IDialogService dialogs;
        public Models.Терминалы _терминалы;
        public RelayCommand ButtonCommandDeleteTerminal;
        public RelayCommand MyButtonClickCommandDeleteTerminal
        {
            get
            {
                return ButtonCommandDeleteTerminal = ButtonCommandDeleteTerminal ?? new RelayCommand(o => { ItemsService.DeleteTerminalsMethod( dialogs, ТТерминалы, НазваниеТерминала); }, o => FuncToEvaluate());
            }
        }
        private bool FuncToEvaluate()
        {
            return ТТерминалы != null;
        }
        public DeleteTerminalViewModel(IItemsService _ItemsService, Models.Терминалы терминалы, IDialogService dialogs)
        {
            ItemsService = _ItemsService;
            _терминалы = терминалы;
            this.dialogs = dialogs;
        }
        private string названиетерминала;
        public string НазваниеТерминала
        {
            get
            {
                return названиетерминала;
            }
            set
            {
                названиетерминала = value;
                OnPropertyChanged("НазваниеТерминала");
            }
        }
        public Models.Терминалы ТТерминалы
        {
            get
            {
                return _терминалы;
            }
            set
            {
                _терминалы = value;
                OnPropertyChanged("ТТерминалы");
                //MyButtonClickCommandDeleteStation.RaiseCanExecuteChanged();
            }
        }
    }
}
