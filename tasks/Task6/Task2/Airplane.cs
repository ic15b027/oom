using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Airplane : IVehicle
    {
        private double m_fuel_level;

        public double Wingspan { get; set; }
        public double Length { get; set; }

        public double BuildPrice
        {
            get
            {
                return Wingspan * Length * 100;
            }
        }

        public Airplane(double fuel_level, double wingspan, double length)
        {
            if (fuel_level < 0 || wingspan < 0 || length < 0)
                throw new Exception();
            Refuel(fuel_level);
            Wingspan = wingspan;
            Length = length;
        }


        public double GetFuelLevel()
        {
            return m_fuel_level;
        }

        public void Refuel(double fuel_amount)
        {
            if (fuel_amount < 0)
                throw new Exception();
            m_fuel_level = fuel_amount;
        }

        public double GetTransportCost(int distance)
        {
            return distance * 0.5 * Length * 0.01;
        }

        public override string ToString()
        {
            return $"Airplane: fuel_level: {GetFuelLevel()}, wingspan: {Wingspan}, length: {Length}";
        }
    }
}
