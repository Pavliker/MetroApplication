using MetroApplication.ViewModels;
using MetroApplication.ViewModels.Отчёты;
using MetroApplication.ViewModels.Станции;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.Services
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;
        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public MainWindowViewModel MainWindowViewModel => _serviceProvider.GetRequiredService<MainWindowViewModel>();
        public StationsViewModel StationsViewModel => _serviceProvider.GetRequiredService<StationsViewModel>();
        public TerminalsViewModel TerminalsViewModel => _serviceProvider.GetRequiredService<TerminalsViewModel>();
        public TabControlViewModel TabControlViewModel => _serviceProvider.GetRequiredService<TabControlViewModel>();
        public MessageBoxViewModel MessageBoxViewModel => _serviceProvider.GetRequiredService<MessageBoxViewModel>();
        public MainWindowLoginViewModel MainWindowLoginViewModel => _serviceProvider.GetRequiredService<MainWindowLoginViewModel>();
        public AuthOPViewModel AuthOPViewModel => _serviceProvider.GetRequiredService<AuthOPViewModel>();
        public RegUViewModel RegU => _serviceProvider.GetRequiredService<RegUViewModel>();
        public ArchiveOfSettingsViewModel ArchiveOfSettings => _serviceProvider.GetRequiredService<ArchiveOfSettingsViewModel>();
        public TerminalsAndStationsViewModel TerminalsAndStationsViewModel => _serviceProvider.GetRequiredService<TerminalsAndStationsViewModel>();
        public SchemOfMetroViewModel SchemOfMetroViewModel => _serviceProvider.GetRequiredService<SchemOfMetroViewModel>();
        public ReportsViewModel ReportsViewModel => _serviceProvider.GetRequiredService<ReportsViewModel>();
        public MessageBoxCorrectViewModel MessageBoxCorrectViewModel => _serviceProvider.GetRequiredService<MessageBoxCorrectViewModel>();

    }
}
