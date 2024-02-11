using MetroApplication.Services;
using MetroApplication.ViewModels;
using Microsoft.AspNetCore.Http.Features;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetroApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для Table1.xaml
    /// </summary>
    public partial class Станции1 : UserControl
    {
       

        public Станции1()
        {
            InitializeComponent();
       

        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set IsRowSelected property to true
          
        }
        private void datagrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            datagrid.UnselectAll();


        }
    }
}
