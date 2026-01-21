using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG_MAUI_Car_Register.Model;


namespace PRG_MAUI_Car_Register.Service
{
    public interface IVehicleStorageService
    {
        
            Task SaveAsync(IEnumerable<Vehicle> students);
            Task<IList<Vehicle>> LoadAsync();
        
    }
}
