using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {

        public string doors = string.Empty;
        public Car(string registrationNumber, string manufacturer, string model, string modelYear, string doors)
    :   base(registrationNumber, manufacturer, model, modelYear)
        {
            Doors = doors;
        }
        public string Doors
        {
            get { return doors; }


            set {
                

                doors = value; }


        }

        
        public override string ToString()
        {
            return base.ToString() + $"\t {Doors}";
        }

    }
}
