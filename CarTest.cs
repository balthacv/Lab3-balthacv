using System;
using NUnit.Framework;
using Expedia;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{
        [Test()]
        public void TestThatCarHasCorrectBasePriceForFiveDays()
        {
            var target = new Car(5);
            Assert.AreEqual(50, target.getBasePrice());
        }
        [Test()]
        public void TestThatCarHasCorrectBasePriceForTenDays()
        {
            var target = new Car(10);
            Assert.AreEqual(80, target.getBasePrice());
        }
        [Test()]
        public void TestThatCarHasCorrectBasePriceForSevenDays()
        {
            var target = new Car(7);
            Assert.AreEqual(10 * 7 * 0.8, target.getBasePrice());
        }
	}
}
