using BookMedicinalPlants.ViewModel;

using System.Windows;


namespace BookMedicinalPlants.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }
    }
}
