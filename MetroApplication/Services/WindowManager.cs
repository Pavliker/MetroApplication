using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Automation;
using MetroApplication.ViewModels;
using MetroApplication.Views;

namespace MetroApplication.Services
{
    public interface IWindowManager
    {
        void ShowWindow(ViewModelBaseMain viewModel);
        void CloseWindow(ViewModelBaseMain viewModel);

    }
    public class WindowManager : IWindowManager
    {

        private readonly WindowMapper _windowMapper;
        public WindowManager(WindowMapper windowMapper) 
        {
            _windowMapper = windowMapper;
        }
        public void ShowWindow(ViewModelBaseMain viewModel)
        {
            var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());

            if (windowType != null)
            {
                var existingWindow = GetOpenWindow(windowType);

                if (existingWindow != null)
                {
                    existingWindow.Focus();
                }
                else
                {
                    var window = Activator.CreateInstance(windowType) as Window;
                    window.DataContext = viewModel;
                    window.Show();
                }
            }

        }

        private Window GetOpenWindow(Type windowType)
        {
            return Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.GetType() == windowType);
        }
        public void CloseWindow(ViewModelBaseMain viewModel)
        {
            var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());

            if (windowType != null)
            {
                var existingWindow = GetOpenWindow(windowType);

                if (existingWindow != null)
                {
                    existingWindow.Close();
                }
            }
        }

    }
}
