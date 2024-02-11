using MetroApplication.ViewModels.Станции;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.Models
{
    [Table("Терминалы")]
    public class Терминалы : INotifyPropertyChanged
    {

        public Терминалы() { }


        public Терминалы(string названиетерминала, short кодстанции, string локальныйадрес, string маскаподсети,string адресшлюза, string адрессервера, short портхоста)
        {
            НазваниеТерминала = названиетерминала;
            КодСтанции = кодстанции;
            ЛокальныйАдрес = локальныйадрес;
            МаскаПодсети = маскаподсети;
            АдресШлюза = адресшлюза;
            АдресСервера = адрессервера;
            ПортХоста = портхоста;
        }


        private string? _названиеТерминала;

        public string? НазваниеТерминала
        {
            get => _названиеТерминала;
            set 
            {
            _названиеТерминала = value;
            }
        }
        [Key]
        public short КодСтанции { get; set; }
        [ForeignKey("КодСтанции")]
        public virtual Станции Станции { get; set; }



        private string? _локальныйАдрес;

        public string? ЛокальныйАдрес
        {
            get => _локальныйАдрес;
            set
            {
                _локальныйАдрес = value;
            }
        }

        private string? _маскаПодсети;
        public string? МаскаПодсети
        {
            get
            {
                return _маскаПодсети;
            }
            set
            {
                _маскаПодсети = value;
            }
        }
        private string? _адресШлюза;
        public string? АдресШлюза
        {
            get
            {
                return _адресШлюза;
            }
            set
            {
                _адресШлюза = value;
            }
        }

        private string? _адресСервера;

        public string? АдресСервера
        {
            get => _адресСервера;
            set
            {
                _адресСервера = value;
            }
        }

        [Column(TypeName = "smallint")]
        private short _портХоста;

        public short ПортХоста
        {
            get => _портХоста;
            set
            {
                _портХоста = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
