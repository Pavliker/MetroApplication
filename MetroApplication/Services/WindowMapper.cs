
using MetroApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

using MetroApplication.Views.Станции;
using MetroApplication.Views;
using MetroApplication.ViewModels.Терминалы;

namespace MetroApplication.Services
{
    public class WindowMapper
    {
        private readonly Dictionary<Type, Type> _mappings = new ();


        public WindowMapper()
        {
            RegisterMapping<MainWindowViewModel, MainWindow>();
            RegisterMapping<AddStationViewModel, AddStationWindow>();
            RegisterMapping<ViewModels.Станции.DeleteStationViewModel, DeleteStationWindow>();
            RegisterMapping<ViewModels.Станции.UpdateStationViewModel, EditStationWindow>();
            RegisterMapping<AddTerminalViewModel, Views.Терминалы.AddTerminalWindow>();
            RegisterMapping <DeleteTerminalViewModel, Views.Терминалы.DeleteTerminalWindow> ();
            RegisterMapping<UpdateTerminalViewModel, Views.Терминалы.EditTerminalWindow>();
            RegisterMapping<MessageBoxViewModel, Views.MessageBox>();
            RegisterMapping<MessageBoxCorrectViewModel, Views.MessageBoxCorrectDialog>();

            RegisterMapping<MainWindowLoginViewModel, MainWindowLogin>();


        }
        public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBaseMain where TWindow : Window 
        { 
        _mappings[typeof (TViewModel)] = typeof (TWindow);
        }


        public Type GetWindowTypeForViewModel(Type viewModelType) 
        {
        _mappings.TryGetValue(viewModelType, out var type);
         return type;
        }





    }

}
