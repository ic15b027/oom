using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Airplane
    {
        private double m_fuel_level;

        public double Wingspan { get; set; }
        public double Length { get; set; }

        public Airplane(double fuel_level, double wingspan, double length)
        {
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
            m_fuel_level = fuel_amount;
        }
    }
}
