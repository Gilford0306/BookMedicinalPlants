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

namespace BookMedicinalPlants.View
{
    /// <summary>
    /// Interaction logic for UserControlPlant.xaml
    /// </summary>
    public partial class UserControlPlant : UserControl
    {
        public static readonly DependencyProperty NameProdProperty = DependencyProperty.Register(nameof(MynameProd), typeof(string), typeof(UserControlPlant));
        public string MynameProd
        {
            get { return (string)GetValue(NameProdProperty); }
            set { SetValue(NameProdProperty, value); }
        }
        public static readonly DependencyProperty PriceProdProperty = DependencyProperty.Register(nameof(MypriceProd), typeof(string), typeof(UserControlPlant));
        public string MypriceProd
        {
            get { return (string)GetValue(PriceProdProperty); }
            set { SetValue(PriceProdProperty, value); }
        }
        public static readonly DependencyProperty PhotoProdProperty = DependencyProperty.Register(nameof(MyphotoProd), typeof(string), typeof(UserControlPlant));
        public string MyphotoProd
        {
            get { return (string)GetValue(PhotoProdProperty); }
            set { SetValue(PhotoProdProperty, value); }
        }

        public UserControlPlant()
        {
            InitializeComponent();
            //prodName.Text = MynameProd;
            //prodPrice.Text = MypriceProd;
            //prodPhoto.Source =(ImageSource)new ImageSourceConverter().ConvertFromString(MyphotoProd);
        }

    }
}