using MetroApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MetroApplication.Models
{
   public class Роли
    {
        private int _КодРоли;
        public Роли() { }
   
        [Key]
        public int КодРоли
        {
            get => _КодРоли;
            set
            {
                _КодРоли = value;
            }
        }
        private string _НазваниеРоли;
        public string НазваниеРоли {
            get => _НазваниеРоли;
            set
            {
                _НазваниеРоли = value;
            }
        }
        [InverseProperty("Роли")]
        public virtual ICollection<Работники> Users { get; set; }
        [InverseProperty("Роли")]
        public virtual ICollection<Операторы> Operators { get; set; }
    }
}
