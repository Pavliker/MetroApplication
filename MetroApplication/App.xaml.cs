using MetroApplication.Services;
using MetroApplication.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using MetroApplication.Models;
using MetroApplication.ViewModels.Станции;
using MetroApplication.ViewModels.Терминалы;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using MetroApplication.Views;
using Microsoft.AspNetCore.Authorization;
using MetroApplication.ViewModels.Отчёты;

namespace MetroApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IConfiguration Configuration { get; }


        private readonly IServiceCollection _services = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;


        public App() 
        {




            //_services.AddSingleton<Станции>();

            _services.AddSingleton<StationsViewModel>();
            _services.AddSingleton<TerminalsViewModel>();
            _services.AddSingleton<TabControlViewModel>();
            _services.AddSingleton<MainWindowViewModel>();
           
           
            
            _services.AddSingleton<AddStationViewModel>();
            _services.AddSingleton<DeleteStationViewModel>();
            _services.AddSingleton<UpdateStationViewModel>();

            _services.AddSingleton<AddTerminalViewModel>();
            _services.AddSingleton<DeleteTerminalViewModel>();
            _services.AddSingleton<UpdateTerminalViewModel>();

            _services.AddSingleton<MessageBoxViewModel>();
            _services.AddSingleton<MessageBoxCorrectViewModel>();



            _services.AddSingleton<ViewModelLocator>();
            _services.AddSingleton<WindowMapper>();
            _services.AddSingleton<INavigationService, NavigationService>();
            _services.AddSingleton<IWindowManager, WindowManager>();
            _services.AddSingleton<IDialogService, DialogService>();
            _services.AddSingleton<IAuthService, AuthService>();
            _services.AddSingleton<IRegistrationService, RegistrationService>();



            _services.AddSingleton<IItemsService, ItemsService>();
            _services.AddSingleton<MainWindowViewModel>();
            _services.AddSingleton<MainWindowLoginViewModel>();
            _services.AddSingleton<AuthOPViewModel>();
            _services.AddSingleton<RegUViewModel>();
            _services.AddSingleton<ArchiveOfSettingsViewModel>();
            _services.AddSingleton<TerminalsAndStationsViewModel>();
            _services.AddSingleton<SchemOfMetroViewModel>();
            _services.AddSingleton<ReportsViewModel>();

            _services.AddSingleton<Func<Type, ViewModelBaseMain>>(serviceProvider => viewModelType => (ViewModelBaseMain)serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider = _services.BuildServiceProvider();    
        }

        
        protected override void OnStartup(StartupEventArgs e)
        {

            //var identity = IAuthService.;
            //if (identity == null)
            //{
            //    var loginWindow = new Login { DataContext = loginViewModel };
            //    loginWindow.Show();
            //}
            //else
            //{
            var mainwindowlogin = _serviceProvider.GetRequiredService<MainWindowLoginViewModel>();
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(mainwindowlogin);
            

            //}
            base.OnStartup(e);


        }

    }
}
