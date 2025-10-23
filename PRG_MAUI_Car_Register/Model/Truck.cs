using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {

        private string loadCapacity = string.Empty;

        public Truck(string registrationNumber, string manufacturer, string model, string modelYear, string loadCapacity)
    :    base(registrationNumber, manufacturer, model, modelYear)
        {
            LoadCapacity = loadCapacity;
        }


        public string LoadCapacity
        {
            get { return loadCapacity; }

            set { loadCapacity = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"\t {loadCapacity}";
        }
    }
}
