using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace InfixToPostfixConverter
{
    public class PostFixTests
    {
        [TestCase("7,3,*,6,9,+,5,/,-",18)]
        public void PostFixEvaluator_GivenPostFix_CheckResult(string postfix, double expected)
        {
            // Arrange
            var evaluator = new PostfixEvaluator();

            // convert string to Queue<string>
            var q = new Queue<string>();
            foreach (var ch in postfix)
            {
                q.Enqueue(ch.ToString());
            }

            // Act
            var result = evaluator.Evaluate(q);

            // Assert
            result.Should().Be(expected);
        }
    }
}
