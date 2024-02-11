using MetroApplication.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace MetroApplication.Views
{
    /// <summary>
    /// Interaction logic for AddStationWindow.xaml
    /// </summary>
    public partial class AddStationWindow : Window
    {
        public AddStationWindow()
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
