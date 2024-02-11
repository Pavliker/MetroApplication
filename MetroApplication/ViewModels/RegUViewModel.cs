using MetroApplication.Commands;
using MetroApplication.Models;
using MetroApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.ViewModels
{
   public class RegUViewModel:ViewModelBaseMain
    {
        RegistrationService registrationService;
        MetroContext context;
        IItemsService itemsService;
        IDialogService dialogService;   
        //Properties
        private string Auth = "Зарегистрироваться";
        public string reg
        {
            get => Auth;
            set => Auth = value;
        }
        private string _login;
        public string login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private SecureString _pass;
        public SecureString password
        {
            get { return _pass; }
            set
            {
                _pass = value;
                OnPropertyChanged(nameof(password));
            }
        }
        private string _пароль;
        public string Пароль
        {
            private get => _пароль;
            set
            {
                _пароль = value;

                // Преобразование строки в SecureString
                SecureString securePassword = new SecureString();
                foreach (char c in value)
                {
                    securePassword.AppendChar(c);
                }

                OnPropertyChanged(nameof(Пароль));
            }
        }

        public RelayCommand RegistrationCommand { get; set; }


        public RegUViewModel(IItemsService itemsService, IDialogService dialogService)
        {
            this.itemsService = itemsService;
            this.dialogService = dialogService;
            context = new MetroContext();
            RegistrationCommand = new RelayCommand(o => RegistrationProcess(login, password, Пароль), o => true);
        }
        public void RegistrationProcess(string login, SecureString password, string пароль)
        {
            try
            {
                
                registrationService = new RegistrationService(context, dialogService, itemsService);
                registrationService.RegisterWorker(login, password, пароль);
            }
            catch (Exception e)
            {
                itemsService.ErrorMessage = e.Message;
            }
        }
      
    }
}
