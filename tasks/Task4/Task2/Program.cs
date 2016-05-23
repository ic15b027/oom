using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[]
            {
                new Airplane(12345.67, 67.33, 52.41),
                new Airplane(23456.78, 78.44, 63.51),
                new Airplane(34567.89, 89.55, 74.61),
                new Bus(1.20, 8.5, 30),
                new Bus(1.30, 9.5, 40),
                new Bus(1.40, 10.5, 50),

            };
            foreach (var a in vehicles)
            {
                Console.WriteLine($"Vehicle is of type: {a.GetType().Name}, it costs {a.BuildPrice} EUR to build. Transport for 1000km costs {a.GetTransportCost(1000)}");
            }

            Console.WriteLine("Starting Serialization:\n");
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var text = JsonConvert.SerializeObject(vehicles, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "vehicles.json");
            File.WriteAllText(filename, text);

            var jsonText = File.ReadAllText(filename);
            Console.WriteLine("File content:\n" + jsonText +"\n");
            var jsonVehicles = JsonConvert.DeserializeObject<IVehicle[]>(jsonText, settings);
            Console.WriteLine("Objects from File:");
            foreach (var a in jsonVehicles)
            {
                Console.WriteLine($"Vehicle is of type: {a.GetType().Name}, it costs {a.BuildPrice} EUR to build. Transport for 1000km costs {a.GetTransportCost(1000)}");
            }
        }
    }
}
