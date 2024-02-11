using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using MetroApplication.ViewModels.Станции;

namespace MetroApplication.Views.Станции
{
    /// <summary>
    /// Interaction logic for EditStationWindow.xaml
    /// </summary>
    public partial class EditStationWindow : Window
    {
  

        public EditStationWindow()
        {
            
            InitializeComponent();


        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


    }
}
