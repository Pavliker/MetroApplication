using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroApplication.Services
{
    public interface IDialogService
    {
        bool? ShowDialog(object dialogViewModel);
    }
    public class DialogService : IDialogService
    {
        private readonly WindowMapper _windowMapper;

        public DialogService(WindowMapper windowMapper)
        {
            _windowMapper = windowMapper;

        }
        public bool? ShowDialog(object dialogViewModel)
        {

            var windowType = _windowMapper.GetWindowTypeForViewModel(dialogViewModel.GetType());

            if (windowType != null)
            {
                var window = Activator.CreateInstance(windowType) as Window;

                window.DataContext = dialogViewModel;
                //window.Owner = owner;

                return window.ShowDialog();
            }
            return true;
        }

    }
}
