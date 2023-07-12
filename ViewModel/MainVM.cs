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
        public ObservableCollection<Plant> SelectedPlant { get; set; }
        private string selectedPlantName;

        //public Plant MySelectedPlant
        //{
        //    get { return selectedPlant; }
        //    set { selectedPlant = value; OnPropertyChanged("MySelectedPlant"); }
        //}


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
                {
                    searchCommand = new RelayCommand(SearchPlant);
                }
                    

                return searchCommand;
            }
        }
        public void SearchPlant()
        {
            SelectedPlant.Clear();
            bool flag = false;
            foreach (Plant plant in Plants)
            {
                if (plant.Name.ToLower().Contains(selectedPlantName.ToLower()) || plant.PublicName.ToLower().Contains(selectedPlantName.ToLower())|| plant.Description.ToLower().Contains(selectedPlantName.ToLower()) || plant.Region.ToLower().Contains(selectedPlantName.ToLower()) || plant.Plus.ToLower().Contains(selectedPlantName.ToLower()) || plant.Minus.ToLower().Contains(selectedPlantName.ToLower()))
                    {
                    flag = true;
                    SelectedPlant.Add(plant);
                }
            }
            if (!flag)
                MessageBox.Show("Растение не найдено");
        }




        public MainVM()
        {
            Plants = new ObservableCollection<Plant>()
            
            //using (MyApplicationContext context = new MyApplicationContext())
            //{
            //    foreach (Drug drug in context.Drugs)
            //    {
            //        Drugs.Add(drug);
            //    }
            //}
            {
                new Plant() { Id = 1, Name = "Name", PublicName = "PublicName", Description = "Description", Region = "region", Plus = "plus", Minus = "Minus", Icon = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Logo_TST.png"},
                new Plant() { Id = 2, Name = "Nme", PublicName = "PublicName", Description = "Description", Region = "region", Plus = "plus", Minus = "Minus", Icon = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Logo_TST.png"}
            };
            SelectedPlant = new ObservableCollection<Plant>();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

//private int id;
//private string name;
//private string publiccname;
//private string description;
//private string region;
//private string plus;
//private string minus;
//private string icon;