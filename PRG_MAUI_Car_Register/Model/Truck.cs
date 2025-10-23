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

        private double loadCapacity;

        public Truck(string registrationNumber, string manufacturer, string model, string modelYear, double loadCapacity)
    :    base(registrationNumber, manufacturer, model, modelYear)
        {
            LoadCapacity = loadCapacity;
        }
         

        public double LoadCapacity
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
