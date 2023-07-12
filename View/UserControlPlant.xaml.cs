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
        public static readonly DependencyProperty NamePlantProperty = DependencyProperty.Register(nameof(MyNamePlant), typeof(string), typeof(UserControlPlant));
        public string MyNamePlant
        {
            get { return (string)GetValue(NamePlantProperty); }
            set { SetValue(NamePlantProperty, value); }
        }
        public static readonly DependencyProperty PnamePlantProperty = DependencyProperty.Register(nameof(MyPublicName), typeof(string), typeof(UserControlPlant));
        public string MyPublicName
        {
            get { return (string)GetValue(PnamePlantProperty); }
            set { SetValue(PnamePlantProperty, value); }
        }


        public static readonly DependencyProperty DescriptionPlantProperty = DependencyProperty.Register(nameof(MyDescription), typeof(string), typeof(UserControlPlant));
        public string MyDescription
        {
            get { return (string)GetValue(DescriptionPlantProperty); }
            set { SetValue(DescriptionPlantProperty, value); }
        }
        public static readonly DependencyProperty PhotoPlantProperty = DependencyProperty.Register(nameof(MyphotoPlant), typeof(string), typeof(UserControlPlant));
        public string MyphotoPlant
        {
            get { return (string)GetValue(PhotoPlantProperty); }
            set { SetValue(PhotoPlantProperty, value); }
        }

        public static readonly DependencyProperty RegionPlantProperty = DependencyProperty.Register(nameof(MyRegion), typeof(string), typeof(UserControlPlant));
        public string MyRegion
        {
            get { return (string)GetValue(RegionPlantProperty); }
            set { SetValue(RegionPlantProperty, value); }
        }

        public static readonly DependencyProperty PlusPlantProperty = DependencyProperty.Register(nameof(MyPlus), typeof(string), typeof(UserControlPlant));
        public string MyPlus
        {
            get { return (string)GetValue(PlusPlantProperty); }
            set { SetValue(PlusPlantProperty, value); }
        }
        public static readonly DependencyProperty MinusPlantProperty = DependencyProperty.Register(nameof(MyMinus), typeof(string), typeof(UserControlPlant));
        public string MyMinus
        {
            get { return (string)GetValue(MinusPlantProperty); }
            set { SetValue(MinusPlantProperty, value); }
        }




        public UserControlPlant()
        {
            InitializeComponent();

        }

    }
}