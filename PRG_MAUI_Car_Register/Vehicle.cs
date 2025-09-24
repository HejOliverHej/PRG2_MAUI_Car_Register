

using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string modelYear = string.Empty;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        public string Model
        {
            get { return model; }
            set { this.model = value;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Du måste skriva in en model för att registrera ditt fordon");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
                {
                    throw new ArgumentException("Modellen får endast innehålla bokstäver, siffror, mellanslag.");
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { this.manufacturer = value;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Du måste skriva in tillvärkare för ditt fordon för att registrera det");
                }
                for(int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[0]))
                    {
                        throw new ArgumentException("Din tillverkare måste bestå av bokstäver");
                    }
                    
                }
                if (!Regex.IsMatch(value, @"^[a-zA-ZåäöÅÄÖ0-9\s\-]+$"))
                {
                    throw new ArgumentException("Märket får endast innehålla bokstäver, siffror, mellanslag och bindestreck.");
                }
            }
        }

        public string ModelYear
        {

            get { return modelYear; }
            set { this.modelYear = value;

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Du måste ange en årsmodell.");
                }

                if (value.Length == 4)
                {
                    for (int i = 0; i < 4; i++){

                        if (!char.IsDigit(value[i])){
                            throw new ArgumentException("Årsmodellen måste bestå av nummer");
                        }
                        else if(i == 0)
                        {
                            if (value[0] == '1' || value[0] == '2') {
                                
                            }
                            else 
                            {
                                throw new ArgumentException("Det första nummret måste vara en etta eler en tvåa");
                            }
                        }
                    }
                }
                else 
                {
                    throw new ArgumentException("Årsmodellen måste vara 4 nummer");
                }
                int year = int.Parse(value);
                if (year > 1886)
                {

                }
                else
                {
                    throw new ArgumentException("DIN bil kan inte vara yngre än 1886 för att det var då blien uppfanns");
                }
                
            }
        }

        //TODO Att spara årsmodell ska möjliggöras, ska valideras, sparas i objektet och visas i UI


        // Klassens  eventuella övriga metoder brukar finnas här, här en override av ToString()

        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model + "\t" + this.modelYear;
        }
    }
}
