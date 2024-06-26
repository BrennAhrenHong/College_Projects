using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace InfixToPostfixConverter
{
    public class InfixTests
    {
        [Test]
        public void QueueToStringBasicStringTest()
        {
            var converter = new InfixToPostFixConverterClass();
            var q = new Queue<string>();
            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            q.Enqueue("D");

            Console.WriteLine(converter.ConvertQueueToString(q));
        }

        [TestCase("[(4*4)-8]+4*(8/2)", "44*8-482/*+")]
        [TestCase("(6+2)*5-8/4", "62+5*84/-")]
        [TestCase("(6.5+2.2)*5.74-8/4", "6.5 2.2 + 5.74 * 8 4 / -")]
        [TestCase("[8-(4/2)*[1+(3)]-1]", "842/13+*-1-")]
        [TestCase("6+6-2", "66+2-")]
        [TestCase("6.5+6.1-2", "6.5 6.1 + 2 -")]
        [TestCase("(5+5)(2+1)", "55+21+*")]
        [TestCase("[5+5](2+1)", "55+21+*")]
        [TestCase("{5+5}(2+1)[2]", "55+21+2*")]
        [TestCase("(5.992+5.12)(2.53+1.85)", "5.992 5.12 + 2.53 1.85 + *")]
        [TestCase("3(2+6)+9(2+1)", "326+*921+*+")]
        [TestCase("3.5*2+1", "3.5 2 * 1 +")]
        [TestCase("sin(3) + 5Cos(2) + sin(1)", "3 sin 5 * + 2 cos + 1 sin")]
        [TestCase("sin(3.1416)", "3.1416 sin")]
        [TestCase("sin(3) + 5", "3 sin 5 +")]
        public void QueueToStringNumTest(string infix, string postfix)
        {
            // Arrange
            var converter = new InfixToPostFixConverterClass();
            
            // Act
            var result = converter.Convert(infix);
            var resultInString = converter.ConvertQueueToString(result);
            // Assert
            resultInString.Should().Be(postfix);
        }
    }
}
