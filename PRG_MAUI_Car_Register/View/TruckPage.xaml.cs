using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class TruckPage : ContentPage
{
    public TruckPage(VehicleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.SelectedPage = "Lastbil";
    }


}