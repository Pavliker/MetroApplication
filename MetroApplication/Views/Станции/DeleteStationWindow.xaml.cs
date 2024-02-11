using System.Windows;
using System.Windows.Input;
using MetroApplication.Models;
using MetroApplication.ViewModels;
using MetroApplication.ViewModels.Станции;

namespace MetroApplication.Views.Станции
{
    /// <summary>
    /// Interaction logic for DeleteStationWindow.xaml
    /// </summary>
    public partial class DeleteStationWindow : Window
    {


        public DeleteStationWindow()
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
