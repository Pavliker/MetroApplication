using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.Models
{
    public class Операторы : INotifyPropertyChanged
    {


        public Операторы() {}
        private int _КодОператора;
        [Key]
        public int КодОператора
        {
            get => _КодОператора;
            set
            {
                _КодОператора = value;
                OnPropertyChanged(nameof(КодОператора));    
            }
        }
        private string _Логин;
        public string Логин
        {
            get
            {
                return _Логин;
            }
            set
            {
                _Логин = value;
                OnPropertyChanged(nameof(Логин));
            }
        }
        private string _Пароль;
        public string Пароль
        {
            get => _Пароль;
            set
            {
                // Hash the password before storing it
                _Пароль = BCrypt.Net.BCrypt.HashPassword(value);
                OnPropertyChanged(nameof(Пароль));
            }
        }

       

        public virtual ICollection<Роли> Роли { get; set; }

        public bool VerifyPassword(string plainTextPassword)
        {
            // Use a secure hashing algorithm (e.g., BCrypt) to verify the password
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, Пароль);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
