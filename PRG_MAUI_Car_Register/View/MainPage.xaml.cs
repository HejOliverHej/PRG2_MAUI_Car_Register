using PRG_MAUI_Car_Register.Model;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {

       
                string regNr = entryRegistrationNumber.Text;
                string manufacturer = entryManufacturer.Text;
                string model = entryModel.Text;
                string modelYear = entryModelYear.Text;

                Vehicle vehicle;



                switch ((Vehicle.Type)pickerType.SelectedIndex)
                {
                    case Vehicle.Type.Bil:
                        vehicle = new Car(regNr, manufacturer, model, modelYear, doors: 4); 
                        break;

                    case Vehicle.Type.MC:
                        vehicle = new MC(regNr, manufacturer, model, modelYear, category: "Sport"); 
                        break;

                    case Vehicle.Type.Lastbil:
                        vehicle = new Truck(regNr, manufacturer, model, modelYear, loadCapacity: 10.0); 
                        break;

                    default:
                        throw new ArgumentException("Ogiltig fordonstypp");
                }


                vehicleList.Add(vehicle);
                listViewVehicles.ItemsSource = null;
                listViewVehicles.ItemsSource = vehicleList;

                entryRegistrationNumber.Text = string.Empty;
                entryManufacturer.Text = string.Empty;
                entryModel.Text = string.Empty;
                entryModelYear.Text = string.Empty;
            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            List<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Bil).ToList();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.MC).ToList();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Lastbil).ToList();
            }
            else
            {
                // Om "Alla" är vald, visa hela listan
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Årsmodell: {foundVehicle.ModelYear}\n" +
                                         $"Typ: {foundVehicle.VehicleType}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

    }
}
