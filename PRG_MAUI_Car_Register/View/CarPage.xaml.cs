using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class CarPage : ContentPage
{
    public CarPage(VehicleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.SelectedPage = "Bil";


    }
   






}