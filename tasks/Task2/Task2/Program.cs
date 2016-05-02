using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Airplane[] planes = new Airplane[]
            {
                new Airplane(12345.67, 67.33, 52.41),
                new Airplane(23456.78, 78.44, 63.51),
                new Airplane(34567.89, 89.55, 74.61),
            };
            foreach (var a in planes)
            {
                Console.WriteLine($"Airplane is {a.Length}m long, has a wingspan of {a.Wingspan}m and is filled with {a.GetFuelLevel()}l of fuel.");
            }
            Console.WriteLine("________________________________________");
            planes[0].Refuel(10000);
            planes[1].Refuel(20000);
            planes[2].Refuel(30000);
            foreach (var a in planes)
            {
                Console.WriteLine($"Airplane is {a.Length}m long, has a wingspan of {a.Wingspan}m and is filled with {a.GetFuelLevel()}l of fuel.");
            }
        }
    }
}
