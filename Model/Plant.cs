using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookMedicinalPlants.Model
{
    public class Plant : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string publiccname;
        private string description;
        private string region;
        private string plus;
        private string minus;
        private string icon;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public string PublicName
        {
            get { return publiccname; }
            set { publiccname = value; OnPropertyChanged("PublicName"); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        public string Region
        {
            get { return region; }
            set { region = value; OnPropertyChanged("Region"); }
        }
        public string Plus
        {
            get { return plus; }
            set { plus = value; OnPropertyChanged("Plus"); }
        }
        public string Minus
        {
            get { return minus; }
            set { minus = value; OnPropertyChanged("Minus"); }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; OnPropertyChanged("Icon"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
