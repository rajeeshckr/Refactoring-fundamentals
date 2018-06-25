using System;
using System.Linq;
using NUnit.Framework;
using HomeHeatingCalc;

namespace UnitTests
{
    [TestFixture]
    public class CalculateCostShould
    {
        [Test]
        public void Return52Point74Given1500AndMild()
        {
            var result = Program.CalculateCost(1500, "M");

            Assert.AreEqual(52.74m, result);
        }

        [Test]
        public void Return87Point9Given2500AndMild()
        {
            var result = Program.CalculateCost(2500, "M");

            Assert.AreEqual(87.9m, result);
        }
    }
}
