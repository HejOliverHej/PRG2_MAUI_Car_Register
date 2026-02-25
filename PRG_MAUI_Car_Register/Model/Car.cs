using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {

        private int doors;
        public Car(string registrationNumber, string manufacturer, string model, string modelYear, int doors)
    :   base(registrationNumber, manufacturer, model, modelYear)
        {
           
            Doors = doors;
        }
        public int Doors
        {
            get { return doors; }

            set {
                if (value < 0 || value > 6)
                {
                    throw new ArgumentException("Antal dörrar måste vara mellan 0 och 6.");
                }

                doors = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"\t {Doors}";
        }

    }
}
