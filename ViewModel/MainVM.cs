using BookMedicinalPlants.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookMedicinalPlants.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {

        public ObservableCollection<Plant> Plants { get; set; }
        private Plant selectedPlant;
        private string selectedPlantName;

        public Plant MySelectedPlant
        {
            get { return selectedPlant; }
            set { selectedPlant = value; OnPropertyChanged("MySelectedPlant"); }
        }


        public string SelectedPlantName
        {
            get { return selectedPlantName; }
            set { selectedPlantName = value; OnPropertyChanged("SelectedPlantName"); }
        }



        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(SearchPlant);

                return searchCommand;
            }
        }
        public void SearchPlant()
        {
            bool flag = false;
            foreach (Plant plant in Plants)
            {

                if (plant.Name.ToLower() == selectedPlantName.ToLower())
                {
                    flag = true;
                    MySelectedPlant = plant;
                }
            }
            if (!flag)
                MessageBox.Show("Растение не найдено");
        }




        public MainVM()
        {
            Plants = new ObservableCollection<Plant>();
            //using (MyApplicationContext context = new MyApplicationContext())
            //{
            //    foreach (Drug drug in context.Drugs)
            //    {
            //        Drugs.Add(drug);
            //    }
            //}
            MySelectedPlant = Plants[0];

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
