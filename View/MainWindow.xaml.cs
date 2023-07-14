using BookMedicinalPlants.ViewModel;
using System.Windows;


namespace BookMedicinalPlants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }


    }
}
