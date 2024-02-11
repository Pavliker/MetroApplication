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
    /// Interaction logic for RegU.xaml
    /// </summary>
    public partial class RegU : UserControl
    {
        public RegU()
        {
            InitializeComponent();
            ShowPasswordCharsCheckBox.IsEnabled = true;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).password = ((PasswordBox)sender).SecurePassword; }
        }
        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {


            if (MyTextBox != null)
            {
                ShowPasswordCharsCheckBox.IsEnabled = false;
        
            }
            else if (MyTextBox == null)
                {
                ShowPasswordCharsCheckBox.IsEnabled = true;

            }
            MyPasswordBox.Visibility = System.Windows.Visibility.Collapsed;
            MyTextBox.Visibility = System.Windows.Visibility.Visible;

            MyTextBox.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (MyPasswordBox!=null)
            {
                ShowPasswordCharsCheckBox.IsEnabled = false;
                ShowPasswordCharsCheckBox.Content = "";
            }
            else if (MyPasswordBox == null)
            {
                ShowPasswordCharsCheckBox.IsEnabled = true;

            }
            MyPasswordBox.Visibility = System.Windows.Visibility.Visible;
            MyTextBox.Visibility = System.Windows.Visibility.Collapsed;

            MyPasswordBox.Focus();
        }
    }
}
