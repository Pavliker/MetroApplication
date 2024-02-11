using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.ViewModels
{
   public class ErrorViewModel:ViewModelBaseMain
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value; 
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }
        public bool HasMessage => !string.IsNullOrEmpty(Message);
     
    }
}
