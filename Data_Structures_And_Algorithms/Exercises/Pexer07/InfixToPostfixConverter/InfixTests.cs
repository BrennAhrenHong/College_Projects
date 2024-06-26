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

        //[TestCase("[(4*4)-8]+4*(8/2)", "44*8-482/*+")]
        //[TestCase("(6+2)*5-8/4", "62+5*84/-")]
        //[TestCase("[8-(4/2)*[1+(3)]-1]", "842/13+*-1-")]
        //[TestCase("6+6-2","66+2-")]
        [TestCase("(5+5)(2+1)","55+21+*")]
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
