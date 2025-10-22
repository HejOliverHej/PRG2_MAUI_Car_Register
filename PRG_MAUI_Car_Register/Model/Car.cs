using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {

        public int Doors;
        public Car(string registrationNumber, string manufacturer, string model, string modelYear, int doors)
    :   base(registrationNumber, manufacturer, model, modelYear)
        {
            Doors = doors;
        }

    }
}
