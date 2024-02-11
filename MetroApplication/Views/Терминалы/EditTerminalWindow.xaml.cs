using MetroApplication.ViewModels;
using MetroApplication.ViewModels.Станции;
using MetroApplication.ViewModels.Терминалы;
using System.Windows;
using System.Windows.Input;

namespace MetroApplication.Views.Терминалы
{
    /// <summary>
    /// Interaction logic for EditTerminalWindow.xaml
    /// </summary>
    public partial class EditTerminalWindow : Window
    {
      

        public EditTerminalWindow()
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
