using MetroApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MetroApplication.Views.Терминалы
{
    /// <summary>
    /// Interaction logic for AddTerminalWindow.xaml
    /// </summary>
    public partial class AddTerminalWindow : Window
    {
        public AddTerminalWindow()
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
