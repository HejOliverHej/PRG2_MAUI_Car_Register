using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class MCPage : ContentPage
{
    public MCPage(VehicleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.SelectedPage = "MC";

    }



}