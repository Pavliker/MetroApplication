using MetroApplication.Services;
using MetroApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication
{
    public class MessageBoxCorrectViewModel : ViewModelBaseMain
    {
        private string _MessageBox;

        public string MessageBox
        {
            get => _MessageBox;
            set
            {
                _MessageBox = value;
                OnPropertyChanged(nameof(MessageBox));
            }
        }
        public IDialogService _DialogService { get; set; }
        public MessageBoxCorrectViewModel(IDialogService _dialogs, string message)
        {
            MessageBox = message;
            _DialogService = _dialogs;
        }
        public void Show()
        {
            if (MessageBox != null)
            {
                _DialogService.ShowDialog(this);
            }
        }
    }
}
