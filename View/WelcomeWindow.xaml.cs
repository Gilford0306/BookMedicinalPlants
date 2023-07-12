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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookMedicinalPlants.View
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
            enter.Visibility = Visibility.Visible;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            //if (Login.Text == "admin" && Password.Text == "admin")
            {
                AdminWindow win1 = new AdminWindow();
                win1.Show();
                this.Close();
            }
        }
    }
}
