using NUnit.Framework;
using System;
using System.Linq;

namespace MoreMethodRefactorings.SubstituteAlgorithm.Bad
{
    public class FizzBuzz
    {
        public string Generate(int input)
        {
            if(input < 2)
            {return "1";}
            if (input == 3)
            {return "Fizz";}
            return "2";
        }
    }

    [TestFixture]
    public class FizzBuzzGenerateShould
    {
        [Test]
        public void ReturnOneGivenOne()
        {
            var generator = new FizzBuzz();

            var result = generator.Generate(1);

            Assert.AreEqual("1", result);
        }

        [Test]
        public void ReturnTwoGivenTwo()
        {
            var generator = new FizzBuzz();

            var result = generator.Generate(2);

            Assert.AreEqual("2", result);
        }

        [Test]
        public void ReturnFizzGivenThree()
        {
            var generator = new FizzBuzz();

            var result = generator.Generate(3);

            Assert.AreEqual("Fizz", result);
        }
    }
}
