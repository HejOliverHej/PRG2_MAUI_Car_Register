using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        public string category = string.Empty;
        public MC(string registrationNumber, string manufacturer, string model, string modelYear, string category)
    :    base(registrationNumber, manufacturer, model, modelYear)
        {
            Category = category;
        }

        public string Category
        {
            get { return category; }

            set { category = value;}
        }

        public override string ToString()
        {
            return base.ToString() + $"\t {category}";
        }
    }
}
