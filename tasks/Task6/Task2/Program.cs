using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerializeExample();
            //PushExample();
            //TaskExample();
        }

        static void SerializeExample()
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
            Console.WriteLine("File content:\n" + jsonText + "\n");
            var jsonVehicles = JsonConvert.DeserializeObject<IVehicle[]>(jsonText, settings);
            Console.WriteLine("Objects from File:");
            foreach (var a in jsonVehicles)
            {
                Console.WriteLine($"Vehicle is of type: {a.GetType().Name}, it costs {a.BuildPrice} EUR to build. Transport for 1000km costs {a.GetTransportCost(1000)}");
            }
        }

        static void PushExample()
        {
            Subject<Airplane> source = new Subject<Airplane>();

            source
                .Sample(TimeSpan.FromSeconds(2.0))
                .Subscribe(x => Console.WriteLine($"read {x}\n"))
                ;

            //source
            //    .Where(x => x.Length > 50)
            //    .Subscribe(x => Console.WriteLine($"read {x}\n"))
            //    ;

            //source
            //    .Skip(4)
            //    .Subscribe(x => Console.WriteLine($"read {x}\n"))
            //    ;

            Thread t = new Thread(() =>
            {
                Random r = new Random();
                while (true)
                {
                    double fuel_level = r.NextDouble() * 10000;
                    double wingspan = r.NextDouble() * 100;
                    double length = r.NextDouble() * 100;
                    Airplane a = new Airplane(fuel_level, wingspan, length);
                    Console.WriteLine($"added {a}\n");
                    source.OnNext(a);
                    Thread.Sleep(1000);
                }
            });
            t.Start();
        }

        static void TaskExample()
        {
            Task task = Calculate(); //takes a lot of time
            task.ContinueWith(t => Console.WriteLine("Factorial finished."));
            task.ContinueWith(t => Console.WriteLine("Tasks finished"));

            Console.WriteLine("\nSomething important happens while calculating factorials\n");
            Thread.Sleep(2000);
            Console.WriteLine("\nThere are still important things happening\n");
            Thread.Sleep(2000);
            Console.WriteLine("\nImportant things finished\n");

            task.ContinueWith(t => Console.WriteLine("Everything finished"));
        }

        static Task<int> SlowCalculation(int number)
        {
            return Task.Run(() =>
            {
                int factorial = 1;
                while (number > 1)
                {
                    factorial = factorial * number;
                    number--;
                    Thread.Sleep(50);
                }
                return factorial;
            });
        }

        static async Task Calculate()
        {
            for (int i = 1; i <= 10; i++)
            {
                int fac = await SlowCalculation(i);
                Console.WriteLine($"factorial: {fac}");
            }
        }
    }
}
