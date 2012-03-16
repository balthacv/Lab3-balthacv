using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture]
    public class FlightTest
    {
        private Flight target;
        private readonly DateTime StartDate = new DateTime(2009, 11, 1);
        private readonly DateTime EndDate1day = new DateTime(2009, 11, 2);
        private readonly DateTime EndDate2days = new DateTime(2009, 11, 3);
        private readonly DateTime EndDate10days = new DateTime(2009, 11, 11);
        private readonly int Miles = 1000;

        [Test]
        public void TestThatFlightInitializes()
        {
            target = new Flight(StartDate, EndDate1day, Miles);
            Assert.IsNotNull(target);
        }

        [Test]
        public void TestThatFlightHasCorrectBasePriceForOneDaySpread()
        {
            target = new Flight(StartDate, EndDate1day, Miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test]
        public void TestThatFlightHasCorrectBasePriceForTwoDaySpread()
        {
            target = new Flight(StartDate, EndDate2days, Miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test]
        public void TestThatFlightHasCorrectBasePriceForTenDaySpread()
        {
            target = new Flight(StartDate, EndDate10days, Miles);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(EndDate10days, StartDate, Miles);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(StartDate, EndDate10days, -5);
        }
    }
}