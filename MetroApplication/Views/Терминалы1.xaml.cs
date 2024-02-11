using System.Windows.Controls;
using System.Windows.Input;
using MetroApplication.ViewModels;
using MetroApplication.Views;



namespace MetroApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для Терминалы.xaml
    /// </summary>
    public partial class Терминалы1 : UserControl
    {
        public Терминалы1()
        {
            InitializeComponent();

        }

        private void datagrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            datagrid.UnselectAll();


        }
    }
}
