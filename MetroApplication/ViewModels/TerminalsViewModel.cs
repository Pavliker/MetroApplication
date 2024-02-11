using MetroApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MetroApplication.Views;
using MetroApplication.Views.Терминалы;
using MetroApplication.ViewModels.Станции;
using MetroApplication.Views.Станции;
using MetroApplication.ViewModels.Терминалы;
using MetroApplication.Services;

namespace MetroApplication.ViewModels
{
    public class TerminalsViewModel : ViewModelBaseMain
    {
        private string? _tabName;
        private IItemsService _ItemsService;
        public  IWindowManager _windowmanager;
        IDialogService dialog;
        AddTerminalViewModel add;
        DeleteTerminalViewModel del;
        UpdateTerminalViewModel update;
        MetroContext dbContext;
        public Models.Терминалы _терминалы;
        public ErrorViewModel errorMessage { get; }
    



        public TerminalsViewModel(IItemsService items, IWindowManager windowmanager, IDialogService dialog)
        {
            itemsService = items;
            dbContext = new MetroContext();
            TabName = "Терминалы";
            itemsService.Терминалы = new ObservableCollection<Models.Терминалы>(dbContext.Terminals.ToList());
            _windowmanager = windowmanager;
            this.dialog = dialog;
        }


        public void Show()
        {
            add = new AddTerminalViewModel(itemsService,dialog);
            _windowmanager.ShowWindow(add);
            
        }

        public void Show1()
        {
            update = new UpdateTerminalViewModel(ТТерминалы, itemsService, dialog);
            _windowmanager.ShowWindow(update);
        }

        public void Show2()
        {
            del = new DeleteTerminalViewModel(itemsService, ТТерминалы, dialog);
            _windowmanager.ShowWindow(del);
        }


        public IItemsService itemsService
        {
            get => _ItemsService;
            set
            {


                _ItemsService = value;
                OnPropertyChanged(nameof(ItemsService));
            }
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
        public event EventHandler FuncToEvulateRequested1;

        private void OnFuncToEvulateRequested1()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                FuncToEvulateRequested1?.Invoke(this, EventArgs.Empty);
            });
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
                RaisePropertyChanged("ТТерминалы");
                OnFuncToEvulateRequested1();
            }
        }
        public bool FuncToEvulate()
        {
            return ТТерминалы != null || ТТерминалы == null;
        }
    }
}
