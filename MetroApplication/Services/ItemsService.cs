using MetroApplication.Models;
using MetroApplication.ViewModels;
using MetroApplication.ViewModels.Станции;
using MetroApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MetroApplication.Services
{
    public interface IItemsService
    {


        public ErrorViewModel errorMessage { get; set; }
        public MessageBoxCorrectViewModel MessageBoxCorrect { get; set; }

        public string ErrorMessage {  set; }

        public MetroContext Metro { get; set; }

        public ObservableCollection<Станции> Станции { get; set; }

        public ObservableCollection<Терминалы> Терминалы { get; set; }

 
        //Stations
        void addStations(IDialogService dialogs, short КодСтанции, string? НазваниеСтанции, string? Адрес, string? Маска, string Шлюз);
        void DeleteStationMethod(IDialogService dialogs, Станции Станции, short КодСтанции);
        void updateStation(IDialogService dialogs, Станции Станции, string? НазваниеСтанции, string? Адрес, string? Маска, string Шлюз);
        //Terminals
        void addTerminals(IDialogService dialogs, short КодСтанции, string? НазваниеТерминала, string? ЛокальныйАдрес, string? МаскаПодсети, string? АдресШлюза, string? АдресСервера, short ПортХоста);
        void DeleteTerminalsMethod(IDialogService dialogs, Терминалы Терминалы, string? НазваниеТерминала);
        void UpdateTerminalsMethod(IDialogService dialogs, Терминалы выбраннаяТерминалы, int КодСтанции, string НазваниеТерминала, string ЛокальныйАдрес, string МаскаПодсети, string АдресШлюза, string АдресСервера, short ПортХоста);
        void SearchTerminal(IDialogService dialogs, string? НазваниеТерминала);
    }
    public class ItemsService : ViewModelBaseMain, IItemsService
    {

        public MessageBoxCorrectViewModel MessageBoxCorrect { get; set; }
        public MessageBoxViewModel MessageBox { get; set; }

        public MetroContext Metro { get; set; }
        public ItemsService()
        {
            Metro = new MetroContext();
        }

     
        public ErrorViewModel errorMessage { get; set; } = new ErrorViewModel();
        public string ErrorMessage
        {
            set => errorMessage.Message = value;
        }
        public StationsViewModel _error { get; set; }
        public ObservableCollection<Станции> станции = new ObservableCollection<Станции>();
        public ObservableCollection<Терминалы> терминалы = new ObservableCollection<Терминалы>();
        public ObservableCollection<Станции> Станции
        {
            get
            {
                return станции;
            }
            set
            {
                станции = value;
                OnPropertyChanged(nameof(Станции));
            }
        }
        public ObservableCollection<Терминалы> Терминалы
        {
            get
            {
                return терминалы;
            }
            set
            {
                терминалы = value;
                OnPropertyChanged(nameof(Терминалы));

            }
        }
        //Поиск терминала
       public void SearchTerminal(IDialogService dialogs, string? НазваниеТерминала)
       {

            if (НазваниеТерминала!=null)
            {
                Терминалы = new ObservableCollection<Терминалы>(терминалы.Where(t => t.НазваниеТерминала.Contains(НазваниеТерминала)));
            }
            else if (НазваниеТерминала == null)
            {
                Терминалы = new ObservableCollection<Терминалы>(Metro.Terminals.ToList());
            }
            else
            {
                MessageBox = new MessageBoxViewModel(dialogs, "Терминал не был найден!");
                MessageBox.Show();  
            }
        }
     
        //Добавление станции
        public void addStations(IDialogService dialogs, short КодСтанции, string? НазваниеСтанции, string? АдресСервера, string? Маска, string Шлюз)
        {
            try
            {
                Станции станции = new Станции();
                станции.КодСтанции = КодСтанции;
                станции.НазваниеСтанции = НазваниеСтанции;
                станции.АдресСервера = АдресСервера;
                станции.Маска = Маска;
                станции.Шлюз = Шлюз;
                Metro.Stations.Add(станции);
                Metro.SaveChanges();
                MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Данные о станции были успешно добавлены");
                MessageBoxCorrect.Show();
                Станции.Add(станции);
               
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;    
            }
        
        }
        //Удаление станции
        public void DeleteStationMethod(IDialogService dialogs, Станции Станциии, short КодСтанции)
        {

            try
            {
                Metro.Configuration.AutoDetectChangesEnabled = false;
                Станциии = (Станции)Metro.Stations.Where(b => b.КодСтанции == Станциии.КодСтанции).First();
                Metro.Stations.Remove(Станциии);
                Metro.SaveChanges();
                MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Данные о станции были успешно удалены");
                MessageBoxCorrect.Show();
                Станции.Remove(Станциии);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                Metro.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        //Редактирование станции
        public void updateStation(IDialogService dialogs, Станции выбраннаяСтанции, string? НазваниеСтанции, string? Адрес, string? Маска, string Шлюз)
        {
            if (выбраннаяСтанции != null)
            {
                using (var contextdb = new MetroContext())
                {
                    var stations = contextdb.Set<Models.Станции>();

                    var updatedStation = stations.SingleOrDefault(s => s.КодСтанции == выбраннаяСтанции.КодСтанции);

                    if (updatedStation != null)
                    {
                        updatedStation.НазваниеСтанции = выбраннаяСтанции.НазваниеСтанции;
                        updatedStation.АдресСервера = выбраннаяСтанции.АдресСервера;
                        updatedStation.Маска = выбраннаяСтанции.Маска;
                        updatedStation.Шлюз = выбраннаяСтанции.Шлюз;
                        contextdb.SaveChanges();
                        MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Данные о станции были успешно изменены");
                        MessageBoxCorrect.Show();
                    }
                }
            }
        }
        //Добавление терминала
        public void addTerminals(IDialogService dialogs, short КодСтанции, string? НазваниеТерминала,  string? ЛокальныйАдрес, string? МаскаПодсети, string? АдресШлюза, string? АдресСервера,short ПортХоста)
        {
            try
            {
                Терминалы терминалы = new Терминалы();
                терминалы.КодСтанции = КодСтанции;
                терминалы.НазваниеТерминала = НазваниеТерминала;
                терминалы.ЛокальныйАдрес = ЛокальныйАдрес;
                терминалы.МаскаПодсети = МаскаПодсети;
                терминалы.АдресШлюза = АдресШлюза;
                терминалы.АдресСервера = АдресСервера;
                терминалы.ПортХоста = ПортХоста;
                Metro.Terminals.Add(терминалы);
                Metro.SaveChanges();
                MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Настройки успешно добавлены");
                MessageBoxCorrect.Show();
                Терминалы.Add(терминалы);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        //Удаление терминала
        public void DeleteTerminalsMethod(IDialogService dialogs, Терминалы Терминалыыы, string? НазваниеТерминала)
        {
            try
            {
                Metro.Configuration.AutoDetectChangesEnabled = false;
                Терминалыыы = (Терминалы)Metro.Terminals.Where(b => b.НазваниеТерминала == Терминалыыы.НазваниеТерминала).First();
                Metro.Terminals.Remove(Терминалыыы);
                Metro.SaveChanges();
                MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Настройки успешно удалены");
                MessageBoxCorrect.Show();
                Терминалы.Remove(Терминалыыы);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                Metro.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        //Редактирование терминала
        public void UpdateTerminalsMethod(IDialogService dialogs, Терминалы выбраннаяТерминалы, int КодСтанции, string НазваниеТерминала, string ЛокальныйАдрес, string МаскаПодсети, string АдресШлюза, string АдресСервера, short ПортХоста)
        {
            try
            {
                if (выбраннаяТерминалы != null)
                {
                    using (var contextdb = new MetroContext())
                    {
                        var stations = contextdb.Set<Models.Терминалы>();
                        var updatedStation = stations.SingleOrDefault(s => s.КодСтанции == выбраннаяТерминалы.КодСтанции);
                        if (updatedStation != null)
                        {
                            updatedStation.НазваниеТерминала = выбраннаяТерминалы.НазваниеТерминала;
                            updatedStation.КодСтанции = выбраннаяТерминалы.КодСтанции;
                            updatedStation.ЛокальныйАдрес = выбраннаяТерминалы.ЛокальныйАдрес;
                            updatedStation.МаскаПодсети = выбраннаяТерминалы.МаскаПодсети;
                            updatedStation.АдресШлюза = выбраннаяТерминалы.АдресШлюза;
                            updatedStation.АдресСервера = выбраннаяТерминалы.АдресСервера;
                            updatedStation.ПортХоста = выбраннаяТерминалы.ПортХоста;
                            contextdb.SaveChanges();
                            MessageBoxCorrect = new MessageBoxCorrectViewModel(dialogs, "Настройки успешно изменены");
                            MessageBoxCorrect.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
