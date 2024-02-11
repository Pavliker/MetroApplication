using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MetroApplication.Models
{
    [Table("Станции")]
    public class Станции : INotifyPropertyChanged
    {

       private  short? _кодСтанции;
       private  string? _названиеСтанции;
       private  string? _адресСервера;
       private  string? _маска;
       private  string? _шлюз;
       private ICollection<Терминалы> терминалы;

        public Станции() { }
        public Станции(short? кодстанции, string названиестанции, string адрессервера, string маска, string шлюз)
        {
            КодСтанции = кодстанции;
            НазваниеСтанции = названиестанции;
            АдресСервера = адрессервера;
            Маска = маска;
            Шлюз = шлюз;
            терминалы = new List<Терминалы>();

        }
        [Key, Required,
         Column(Order = 0),
         DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short? КодСтанции
        {
            get { return _кодСтанции; }
            set
            {
                if (_кодСтанции != value)
                {
                    _кодСтанции = value;
                    OnPropertyChanged("КодСтанции");

                }
            }
        }

        public string? НазваниеСтанции
        {
            get => _названиеСтанции;
            set
            {
                _названиеСтанции = value;
               OnPropertyChanged (nameof(НазваниеСтанции));
            }
        }
    
        public string? АдресСервера
        {
            get => _адресСервера;
            set
            {
                _адресСервера = value;
                OnPropertyChanged(nameof(АдресСервера));
            }
        }

        public string? Маска
        {
            get => _маска;
            set
            {
                _маска = value;
                OnPropertyChanged(nameof(Маска));
            }
        }

        public string? Шлюз
        {
            get => _шлюз;
            set
            {
                _шлюз = value;
                OnPropertyChanged(nameof(Шлюз));
            }
        } 

        public virtual ICollection<Терминалы> Терминалы { get => терминалы; set => терминалы = value; }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
