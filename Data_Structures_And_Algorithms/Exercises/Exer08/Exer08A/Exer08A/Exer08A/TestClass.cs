using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Exer08A
{
    public class TestClass
    {
        [Test]
        public void SummingSeriesTesting()
        {
            int input = 5;

            var trial = new GCD_SS_SDI();
            Console.WriteLine(trial.SummingSeries(input));
        }

        [TestCase("100", 1)]
        [TestCase("123", 6)]
        [TestCase("246", 12)]
        [TestCase("1234", 10)]
        [TestCase("58710725", 35)]
        [TestCase("932216", 23)]
        public void SummingTheDigits(string input, int expected)
        {

            var trial = new GCD_SS_SDI();
            Console.WriteLine(trial.SumofIntegers(input));
        }

    }
}
