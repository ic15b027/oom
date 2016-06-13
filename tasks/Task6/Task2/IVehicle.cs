using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface IVehicle
    {
        double BuildPrice { get; }

        double GetTransportCost(int distance);
    }
}
