using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Bus : IVehicle
    {
        private double m_ticket_cost;

        public double Length { get; set; }
        public int Seats { get; set; }

        public double BuildPrice
        {
            get
            {
                return Length * Seats * 50;
            }
        }

        public Bus(double ticket_cost, double length, int seats)
        {
            if (ticket_cost < 0 || length < 0 || seats < 0)
                throw new Exception();
            UpdateTicketCost(ticket_cost);
            Length = length;
            Seats = seats;
        }


        public double GetTicketCost()
        {
            return m_ticket_cost;
        }

        public void UpdateTicketCost(double ticket_cost)
        {
            if (ticket_cost < 0)
                throw new Exception();
            m_ticket_cost = ticket_cost;
        }

        public double GetTransportCost(int distance)
        {
            return distance * 2 / Seats * 10;
        }
    }
}
