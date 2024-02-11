using MetroApplication.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroApplication.Services
{
   public interface INavigationService
    {
        ViewModelBaseMain CurrentView { get; }
        void NavigateTo<T> () where T : ViewModelBaseMain;
    }


   public class NavigationService : ViewModelBaseMain, INavigationService
    {
    
        private readonly Func<Type, ViewModelBaseMain> _viewModelFactory;
        public ViewModelBaseMain _currentView;
        public ViewModelBaseMain CurrentView
        {
            get => _currentView;
          private  set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        public NavigationService(Func<Type, ViewModelBaseMain> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<TViewModel>()where TViewModel : ViewModelBaseMain
        {
         
          ViewModelBaseMain viewModel =_viewModelFactory.Invoke(typeof(TViewModel));
          CurrentView = viewModel;
        }





    }


}
