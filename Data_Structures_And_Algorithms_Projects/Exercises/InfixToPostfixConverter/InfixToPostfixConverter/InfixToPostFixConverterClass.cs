using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfixToPostfixConverter
{
    public class InfixToPostFixConverterClass
    {
        public string ConvertQueueToString(Queue<string> expression)
        {
            var sb = new StringBuilder();
            foreach (var s in expression)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
        public Queue<string> Convert(string infix)
        {
            var delimiterChecker = new DelimiterChecker();
            if(!delimiterChecker.HasMatchingDelimiter(infix))
                throw new Exception("Invalid expression. Check if delimiters matches");

            var postfix = new Queue<string>();
            var stack = new Stack<string>();

            foreach (char ch in infix)
            {
                if (char.IsDigit(ch)) postfix.Enqueue(ch.ToString()); // #A
                else if (delimiterChecker.IsOpeningDelimeter(ch.ToString())) stack.Push(ch.ToString()); // #B
                else if (IsOperator(ch.ToString()))
                {
                    if (stack.Count == 0) stack.Push(ch.ToString());
                    else
                    {
                        string topOfStack = stack.Peek();
                        int chPrecedence = GetPrecedence(ch.ToString());

                        // #C
                        while (stack.Count > 0 && IsOperator(topOfStack) && GetPrecedence(topOfStack) >= chPrecedence)
                        {
                            string poppedOperator = stack.Pop();
                            postfix.Enqueue(poppedOperator);
                            if (stack.Count > 0) topOfStack = stack.Peek();
                        }

                        // #D
                        stack.Push(ch.ToString());
                    }
                }

                else if (delimiterChecker.IsClosingDelimeter(ch.ToString()))
                {
                    while (!delimiterChecker.IsOpeningDelimeter(stack.Peek()))
                    {
                        postfix.Enqueue(stack.Pop());
                    }
                    // discard the opening delimiter
                    stack.Pop();
                }
            }

            while (stack.Count > 0)
            {
                postfix.Enqueue(stack.Pop());
            }

            return postfix;
        }

        // ----------------------------
        // #A: Digit: append to postfix
        // #B: Opening Delimiter: Push to stack
        // #C: Check if current character is an operator AND its precedence is lower or equal
        // to the top of the stack, if equal or higher Pop the top of the stack to postfix
        // #D: All operators at the top of the stack with higher or equal precedence than
        // current operator HAS BEEN POPPED, then push current operator to the stack

        public bool IsOperator(string op)
        {
            var ops = new char[] {'^', '*', '/', '+', '-'};

            var isContainedInTheArray = op.IndexOfAny(ops);
            return isContainedInTheArray >= 0;


        }

        private int GetPrecedence(string op)
        {
            if (op == "^") return 3;
            if (op == "*") return 2;
            if (op == "/") return 2;
            if (op == "+") return 1;
            if (op == "-") return 1;

            throw new Exception("This is NOT a valid operator.");
        }
    }
}
