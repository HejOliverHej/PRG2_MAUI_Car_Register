using Microsoft.Maui.Graphics;
using ObjCBindings;
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
        private string manufacturer { get; set; }
        private string model { get; set; }
        private string modelYear { get; set; }
        private string doors { get; set; }
        private string category { get; set; }
        private double loadCapacity { get; set; }


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
        public string Doors
        {
            get { return doors; }

            set { doors = value; OnPropertyChanged(nameof(Doors)); }
        }
        public string Varible
        {
            get { return varible; }

            set { varible = value; OnPropertyChanged(nameof(varible)); }
        }
        public string Varible
        {
            get { return varible; }

            set { varible = value; OnPropertyChanged(nameof(varible)); }
        }

        public ObservableCollection<Vehicle> vehicleList { get; set; } = new();

        public ICommand OnRegisterCommand {get; }

        public VehicleViewModel()
        {
            OnRegisterCommand = new Command(RegisterCommand);
        }


        private void RegisterCommand()
        {
            try
            {


                Vehicle vehicle;
                string selectedType = pickerType.SelectedItem?.ToString();

                switch (selectedType)
                {
                    case "Bil":
                        if (!int.TryParse(doors, out int doors))
                        {
                            throw new ArgumentException("Antal dörrar måste vara ett heltal.");
                        }
                        vehicle = new Car(regNr, manufacturer, model, modelYear, doors);
                        break;

                    case "MC":
                        vehicle = new MC(regNr, manufacturer, model, modelYear, category);
                        break;

                    case "Lastbil":
                        if (!double.TryParse(loadCapacity, out double loadCapacity))
                        {
                            throw new ArgumentException("Antal dörrar måste vara ett heltal.");
                        }
                        vehicle = new Truck(regNr, manufacturer, model, modelYear, loadCapacity);
                        break;

                    default:
                        throw new ArgumentException("Ogiltig fordonstypp");
                }


                vehicleList.Add(vehicle);
                

                regNr = string.Empty;
                manufacturer = string.Empty;
                model = string.Empty;
                modelYear = string.Empty;
                category = string.Empty;
                doors = 0;
                loadCapacity = 0;
            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }

        }


    }
}
