using System;
using System.Collections.Generic;
using System.Text;

namespace InfixToPostfixConverter
{
    class PostfixEvaluator
    {
        public double Evaluate(Queue<string> postfix)
        {
            var digits = new Stack<string>();

            while (postfix.Count > 0)
            {
                var current = postfix.Dequeue();

                // #A
                if (double.TryParse(current, out double result))
                    digits.Push(current);
                else if (IsOperator(current))
                {
                    var x = digits.Pop();
                    var y = digits.Pop();

                    var calculated = Calculate(x, y, current);
                    digits.Push(calculated.ToString());
                }
            }

            return double.Parse(digits.Peek());
        }

        private double Calculate(string x, string y, string op)
        {
            var xValue = double.Parse(x);
            var yValue = double.Parse(y);

            switch (op)
            {
                case "^":
                    return Math.Pow(yValue, xValue);
                case "/":
                    return yValue / xValue;
                case "*":
                    return xValue * yValue;
                case "+":
                    return xValue + yValue;
                case "-":
                    return yValue - xValue;
                default:
                    throw new Exception("Invalid Operator");
            }
        }

        public bool IsOperator(string op)
        {
            var ops = new char[] { '^', '*', '/', '+', '-' };

            var isContainedInTheArray = op.IndexOfAny(ops);
            return isContainedInTheArray >= 0;
        }
    }
}
