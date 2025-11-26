using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using PRG_MAUI_Car_Register.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class VehicleViewModel : BaseViewModel
    {
        private string regNr;
        private string manufacturer;
        private string model;
        private string modelYear;
        private int doors;
        private string category;
        private double loadCapacity;
        private string selectedType;
        


        public string RegNr
        {
            get { return regNr; }

            set { regNr = value; OnPropertyChanged(nameof(RegNr));}
        }
        public string Manufacturer
        {
            get { return manufacturer; }

            set { manufacturer = value; OnPropertyChanged(nameof(Manufacturer)); }
        }
        public string Model
        {
            get { return model; }

            set { model = value; OnPropertyChanged(nameof(Model)); }
        }
        public string ModelYear
        {
            get { return modelYear; }

            set { modelYear = value; OnPropertyChanged(nameof(ModelYear)); }
        }
        public int Doors
        {
            get { return doors; }

            set { doors = value; OnPropertyChanged(nameof(Doors)); }
        }
        public string Category
        {
            get { return category; }

            set { category = value; OnPropertyChanged(nameof(Category)); }
        }
        public double LoadCapacity
        {
            get { return loadCapacity; }

            set { loadCapacity = value; OnPropertyChanged(nameof(LoadCapacity)); }
        }

        public string SelectedType
        {
            get => selectedType;
            set { selectedType = value; OnPropertyChanged(nameof(SelectedType)); UpdateVisibility(); }
        }
        private bool showDoors;
        public bool ShowDoors
        {
            get => showDoors;
            set { showDoors = value; OnPropertyChanged(nameof(ShowDoors)); }
        }

        private bool showCategory;
        public bool ShowCategory
        {
            get => showCategory;
            set { showCategory = value; OnPropertyChanged(nameof(ShowCategory)); }
        }

        private bool showLoadCapacity;
        public bool ShowLoadCapacity
        {
            get => showLoadCapacity;
            set { showLoadCapacity = value; OnPropertyChanged(nameof(ShowLoadCapacity)); }
        }

        private string searchResult;
        public string SearchResult
        {
            get => searchResult;
            set { searchResult = value; OnPropertyChanged(nameof(SearchResult)); }
        }

        private string searchTerm;
        public string SearchTerm
        {
            get => searchTerm;
            set { searchTerm = value; OnPropertyChanged(nameof(SearchTerm)); }
        }



        public ObservableCollection<string> VehicleTypes { get; } = new ObservableCollection<string> { "Bil", "MC", "Lastbil" };
        public ObservableCollection<Vehicle> vehicleslist { get; } = new ObservableCollection<Vehicle>();

        public ICommand OnRegisterCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand FilterCommand { get; }
        public VehicleViewModel()
        {
            OnRegisterCommand = new Command(RegisterCommand);
            SearchCommand = new Command<string>(SearchVehicle);
            FilterCommand = new Command<string>(FilterVehicles);

            SelectedType = "Bil";
        }

        private void UpdateVisibility()
        {
            ShowDoors = SelectedType == "Bil";
            ShowCategory = SelectedType == "MC";
            ShowLoadCapacity = SelectedType == "Lastbil";
            ResetFields();
        }


        private async void RegisterCommand()
        {
            try
            {

                Vehicle vehicle;

                switch (SelectedType)
                {
                    case "Bil":
                        vehicle = new Car(regNr, manufacturer, model, modelYear, doors);
                        break;
                    case "MC":
                        vehicle = new MC(regNr, manufacturer, model, modelYear, category);
                        break;
                    case "Lastbil":
                        vehicle = new Truck(regNr, manufacturer, model, modelYear, loadCapacity);
                        break;
                    default:
                        throw new ArgumentException("Ogiltig fordonstypp");
                }

                vehicleslist.Add(vehicle);
                
                ResetFields();
            }
            catch (ArgumentException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", ex.Message, "OK");


            }

        }
        private void ResetFields()
        {
            RegNr = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            ModelYear = string.Empty;
            Category = string.Empty;
            Doors = 0;
            LoadCapacity = 0;
        }

        private void SearchVehicle(string regNr)
        {
            var found = vehicleslist.FirstOrDefault(v =>
    string.Equals(v.RegistrationNumber, regNr, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                string typ = found is Car ? "Bil" : found is MC ? "MC" : found is Truck ? "Lastbil" : "Okänd";
                string extra = found switch
                {
                    Car car => $"Antal dörrar: {car.Doors}",
                    MC mc => $"Kategori: {mc.Category}",
                    Truck truck => $"Lastkapacitet: {truck.LoadCapacity} ton",
                    _  => string.Empty
                };
                SearchResult = $"Fordon hittat:\n{found.RegistrationNumber}, {found.Manufacturer}, {found.Model}, {found.ModelYear}, Typ: {typ}, {extra}";
            }
            else
            {
                SearchResult = "Inget fordon hittades.";
            }
        }

        private void FilterVehicles(string filter)
        {
            var filtered = filter switch
            {
                "Bil" => vehicleslist.Where(v => v is Car).ToList(),
                "MC" => vehicleslist.Where(v => v is MC).ToList(),
                "Lastbil" => vehicleslist.Where(v => v is Truck).ToList(),
                _ => vehicleslist.ToList()
            };

            
            foreach (var v in filtered)
                vehicleslist.Add(v);
        }
    }
}
