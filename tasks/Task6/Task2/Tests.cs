using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void CanCreateAirplane()
        {
            Airplane a = new Airplane(1000.5, 90.5, 80.5);
            Assert.IsTrue(a.GetFuelLevel() == 1000.5);
            Assert.IsTrue(a.Wingspan == 90.5);
            Assert.IsTrue(a.Length == 80.5);
        }

        [Test]
        public void CannotCreateAirplaneWithNegativeFuelLevel()
        {
            Assert.Catch(() =>
            {
                Airplane a = new Airplane(-1000.5, 90.5, 80.5);
            });
        }

        [Test]
        public void CannotCreateAirplaneWithNegativeWingspan()
        {
            Assert.Catch(() =>
            {
                Airplane a = new Airplane(1000.5, -90.5, 80.5);
            });
        }

        [Test]
        public void CannotCreateAirplaneWithNegativeLength()
        {
            Assert.Catch(() =>
            {
                Airplane a = new Airplane(1000.5, 90.5, -80.5);
            });
        }

        [Test]
        public void CannotRefuelNegative()
        {
            Assert.Catch(() =>
            {
                Airplane a = new Airplane(1000.5, 90.5, 80.5);
                a.Refuel(-1000.5);
            });
        }



        [Test]
        public void CanCreateBus()
        {
            Bus b = new Bus(1.5, 10.5, 30);
            Assert.IsTrue(b.GetTicketCost() == 1.5);
            Assert.IsTrue(b.Length == 10.5);
            Assert.IsTrue(b.Seats == 30);
        }

        [Test]
        public void CannotCreateBusWithNegativeTicketCost()
        {
            Assert.Catch(() =>
            {
                Bus b = new Bus(-1.5, 10.5, 30);
            });
        }

        [Test]
        public void CannotCreateBusWithNegativeLength()
        {
            Assert.Catch(() =>
            {
                Bus b = new Bus(1.5, -10.5, 30);
            });
        }

        [Test]
        public void CannotCreateBusWithNegativeSeats()
        {
            Assert.Catch(() =>
            {
                Bus b = new Bus(1.5, 10.5, -30);
            });
        }

        [Test]
        public void CannotUpdateTicketPriceNegative()
        {
            Assert.Catch(() =>
            {
                Bus b = new Bus(1.5, 10.5, 30);
                b.UpdateTicketCost(-1.5);
            });
        }
    }
}
