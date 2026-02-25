using System.Text.Json;
using System.Text.Json.Serialization;
using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.Service;

namespace PRG_MAUI_Car_Register.Service
{
    public class JsonVehicleStorageService : IVehicleStorageService
    {
        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
            IncludeFields = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonVehicleStorageService()
        {
            _filePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "vehicles.json");
        }

        public async Task SaveAsync(IEnumerable<Vehicle> vehicles)
        {
            var json = JsonSerializer.Serialize(vehicles, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<IList<Vehicle>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Vehicle>();

            var json = await File.ReadAllTextAsync(_filePath);

            var rawList = JsonSerializer.Deserialize<List<JsonElement>>(json, _options);
            var vehicles = new List<Vehicle>();

            if (rawList == null)
                return vehicles;

            foreach (var element in rawList)
            {
                if (!element.TryGetProperty("Type", out var typeProp))
                    continue;

                var type = typeProp.GetString();

                Vehicle v = type switch
                {
                    "Car" => element.Deserialize<Car>(_options),
                    "MC" => element.Deserialize<MC>(_options),
                    "Truck" => element.Deserialize<Truck>(_options),
                    _ => null
                };

                if (v != null)
                    vehicles.Add(v);
            }

            return vehicles;
        }
    }
}

