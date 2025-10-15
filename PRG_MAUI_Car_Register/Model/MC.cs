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
        public string Category;
        public MC(string registrationNumber, string manufacturer, string model, string modelYear, string category)
    :    base(Type.MC, registrationNumber, manufacturer, model, modelYear)
        {
            Category = category;
        }

    }
}
