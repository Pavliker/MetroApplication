using MetroApplication.Services;
using MetroApplication.ViewModels;
using MetroApplication.Views;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication
{
    public class MessageBoxViewModel : ViewModelBaseMain
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

        public  IDialogService _DialogService { get; set; }
        public MessageBoxViewModel(IDialogService dialogs, string message)
        {
            MessageBox = message;
            _DialogService = dialogs;   
        }
        public  void Show()
        {
            if (MessageBox != null)
            {
                _DialogService.ShowDialog(this);
            }
        }
    }
}
