using BookMedicinalPlants.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BookMedicinalPlants.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        private int change = 0;
        public ObservableCollection<Plant> Plants { get; set; }
        public ObservableCollection<Plant> SelectedPlant { get; set; }
        private Plant mySelectedPlant;
        private string selectedPlantName;

        public Plant MySelectedPlant
        {
            get { return mySelectedPlant; }
            set
            {
                mySelectedPlant = value;
                OnPropertyChanged("MySelectedPlant");
                if (mySelectedPlant != null)
                {
                    change = mySelectedPlant.Id;
                }
            }
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
            if (selectedPlantName != null)
            {
                foreach (Plant plant in Plants)
                {
                    if (plant.Name.ToLower().Contains(selectedPlantName.ToLower()) || plant.PublicName.ToLower().Contains(selectedPlantName.ToLower()) || plant.Description.ToLower().Contains(selectedPlantName.ToLower()) || plant.Region.ToLower().Contains(selectedPlantName.ToLower()) || plant.Plus.ToLower().Contains(selectedPlantName.ToLower()) || plant.Minus.ToLower().Contains(selectedPlantName.ToLower()))
                    {
                        flag = true;
                        SelectedPlant.Add(plant);
                    }
                }
                if (!flag)
                    MessageBox.Show("Растение не найдено");

            }

        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(SavePlant);
                }


                return saveCommand;
            }
        }
        public void SavePlant()
        {
            if (change > 0)
            {

                using (MyApplicationContext context = new MyApplicationContext())
                {
                    var oldData = context.Plants.FirstOrDefault(x => x.Id == change);
                    oldData.Name = MySelectedPlant.Name;
                    oldData.PublicName = MySelectedPlant.PublicName;
                    oldData.Description = MySelectedPlant.Description;
                    oldData.Plus = MySelectedPlant.Plus;
                    oldData.Minus = MySelectedPlant.Minus;
                    oldData.Icon = MySelectedPlant.Icon;
                    context.Plants.Update(oldData);
                    context.SaveChanges();
                }
                MessageBox.Show("Изменения сохранены");
            }

        }



        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddPlant);
                }


                return addCommand;
            }
        }
        public void AddPlant()
        {
            using (MyApplicationContext context = new MyApplicationContext())
            {



                context.Plants.Add(new Plant() { Name = "Название", PublicName = "Название народное", Description = "Описание", Region = "Регион", Plus = "Положительные свойства", Minus = "Отрицательные  свойства", Icon = "URL фото" });
                context.SaveChanges();
                Plants.Clear();
                foreach (Plant plant in context.Plants)
                    {
                        Plants.Add(plant);
                    }

            }

        }


        private RelayCommand delCommand;

        public RelayCommand DelCommand
        {
            get
            {
                if (delCommand == null)
                {
                    delCommand = new RelayCommand(DelPlant);
                }


                return delCommand;
            }
        }
        public void DelPlant()
        {
            if (change > 0)
            {
                using (MyApplicationContext context = new MyApplicationContext())
                {

                    context.Plants.Remove(context.Plants.FirstOrDefault(z => z.Id.Equals(change)));
                    context.SaveChanges();
                    MessageBox.Show("Растение удалено");
                    Plants.Remove(Plants.FirstOrDefault(x => x.Id.Equals(change)));
                    change = 0;
                }

            }
        }




        public MainVM()
        {
            Plants = new ObservableCollection<Plant>();


            using (MyApplicationContext context = new MyApplicationContext())
            {
                foreach (Plant plant in context.Plants)
                {
                    Plants.Add(plant);
                }
            }
            //{
            //    new Plant() { Id = 1, Name = "Name", PublicName = "PublicName", Description = "Description", Region = "region", Plus = "plus", Minus = "Minus", Icon = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Logo_TST.png"},
            //    new Plant() { Id = 2, Name = "Nme", PublicName = "PublicName", Description = "Description", Region = "region", Plus = "plus", Minus = "Minus", Icon = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Logo_TST.png"}
            //};
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
