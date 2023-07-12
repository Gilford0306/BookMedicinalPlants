using BookMedicinalPlants.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Windows;


namespace BookMedicinalPlants.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {

        public ObservableCollection<Plant> Plants { get; set; }
        public ObservableCollection<Plant> SelectedPlant { get; set; }
        private Plant mySelectedPlant;
        private string selectedPlantName;

        public Plant MySelectedPlant
        {
            get { return mySelectedPlant; }
            set { mySelectedPlant = value; OnPropertyChanged("MySelectedPlant"); }
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

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(SavePlant);
                }


                return searchCommand;
            }
        }
        public void SavePlant()
        {

                using (MyApplicationContext context = new MyApplicationContext())
                {

                    context.Plants.Add(new Plant() { Name = "test", PublicName = "test", Description = "test" });
                    context.SaveChanges();
                    MessageBox.Show("Растение добавлено");
                }
            
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
