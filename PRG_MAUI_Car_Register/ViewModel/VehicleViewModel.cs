using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class VehicleViewModel : BaseViewModel
    {

        private string model; public string Model { get { return model; } set { model = value; OnPropertyChanged(nameof(Model)); } }
    }
}
