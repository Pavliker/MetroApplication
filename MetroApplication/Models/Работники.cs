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
    public class Работники : INotifyPropertyChanged
    {
        public Работники() { }
 

        public Работники(int кодпользователя, DateTime датадобавления, string логин,string пароль) 
        {
            КодРаботника = кодпользователя;
            ДатаДобавления = датадобавления;
            Логин = логин;
            Пароль = пароль;
            ХэшированныйПароль = Пароль;
        }

        private int _КодРаботника;
        [Key]
        public int КодРаботника
        {
            get => _КодРаботника;
            set
            {
                _КодРаботника = value;
                OnPropertyChanged(nameof(КодРаботника));
            }
        }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        private DateTime _ДатаДобавления;
        public DateTime ДатаДобавления
        {
            get => _ДатаДобавления;
            set
            {
                _ДатаДобавления = value;
                OnPropertyChanged(nameof(ДатаДобавления));
            }
        }
        private string _Логин;
        public string Логин
        {
            get => _Логин;
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
            set { _Пароль = value;
                OnPropertyChanged(nameof(Пароль));
            }
        }

        private string _ХэшированныйПароль;
        public string ХэшированныйПароль
        {
            get => _ХэшированныйПароль;
            set
            {
                _ХэшированныйПароль = value;
                OnPropertyChanged(nameof(ХэшированныйПароль));
            }
        }
        public virtual ICollection<Роли> Роли { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
