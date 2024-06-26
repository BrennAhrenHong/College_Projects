using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                if(sb.Length > 1)
                    if (sb[^1] == ' ' && s == " ") continue;

                sb.Append(s);
            }

            if (sb[0] == ' ') sb.Remove(0,1);

            string processed = ConvertCodeBackToTrigoFn(sb.ToString());

            return processed;
        }
        public Queue<string> Convert(string infix)
        {
            var delimiterChecker = new DelimiterChecker();
            if(!delimiterChecker.HasMatchingDelimiter(infix))
                throw new Exception("Invalid expression. Check if delimiters matches");

            
            //Converting Trigo to Codes
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                if (char.IsLetter(ch) && char.IsLetter(infix[i + 1]))
                {
                    StringBuilder trigoFn = new StringBuilder();
                    trigoFn.Append(infix[i]);
                    trigoFn.Append(infix[i + 1]);
                    trigoFn.Append(infix[i + 2]);

                    infix = infix.Replace(trigoFn.ToString(), ConvertTrigoFnToCode(trigoFn.ToString()));
                }
            }
            
            
            //Adding * to implications
            for (int x = 1; x < infix.Length; x++)
            {
                char ch = infix[x];
                int prevIndex = x - 1;

                if (ch == '(')
                {
                    if (!IsOperator(infix[prevIndex].ToString()) && !delimiterChecker.IsOpeningDelimeter(infix[prevIndex].ToString()) && !char.IsLetter(infix[prevIndex]))
                        infix = infix.Insert(x, "*");
                }
                else if (char.IsLetter(infix[x]) && char.IsDigit(infix[prevIndex])) infix = infix.Insert(x, "*");
            }


            var postfix = new Queue<string>();
            var stack = new Stack<string>();
            bool infixContainsDecimal = infix.Contains('.');
            bool infixContainsTrigoFn = infix.Contains('S') || infix.Contains('C') || infix.Contains('T') || infix.Contains('I') ||
                                        infix.Contains('O') || infix.Contains('A');

            foreach (char ch in infix)
            {
                if (char.IsDigit(ch) || ch == '.') postfix.Enqueue(ch.ToString()); // #A
                else if (delimiterChecker.IsOpeningDelimeter(ch.ToString())) stack.Push(ch.ToString()); // #B
                else if (IsOperator(ch.ToString()))
                {
                    if (infixContainsDecimal || infixContainsTrigoFn) postfix.Enqueue(" ");

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
                            if (infixContainsDecimal || infixContainsTrigoFn) postfix.Enqueue(" ");

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
                        if (infixContainsDecimal || infixContainsTrigoFn) postfix.Enqueue(" ");

                        postfix.Enqueue(stack.Pop());
                    }
                    // discard the opening delimiter
                    stack.Pop();
                }
            }

            while (stack.Count > 0)
            {
                if (infixContainsDecimal || infixContainsTrigoFn) postfix.Enqueue(" ");
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
            var ops = new char[] {'^', '*', '/', '+', '-', 'S', 'C', 'T', 'I', 'O', 'A'};

            var isContainedInTheArray = op.IndexOfAny(ops);
            return isContainedInTheArray >= 0;


        }

        private string ConvertTrigoFnToCode(string trigo)
        {
            trigo = trigo.ToLower();
            if (trigo == "sin") return "S";
            if (trigo == "cos") return "C";
            if (trigo == "tan") return "T";

            if (trigo == "csc") return "I";
            if (trigo == "sec") return "O";
            if (trigo == "cot") return "A";

            throw new Exception("This is NOT a valid operator.");
        }

        private string ConvertCodeBackToTrigoFn(string expression)
        {
            if (expression.Contains('S')) expression = expression.Replace("S", "sin");
            if (expression.Contains('C')) expression = expression.Replace("C", "cos");
            if (expression.Contains('T')) expression = expression.Replace("T", "tan");

            if (expression.Contains('I')) expression = expression.Replace("I", "csc");
            if (expression.Contains('O')) expression = expression.Replace("O", "sec");
            if (expression.Contains('A')) expression = expression.Replace("A", "cot");

            return expression;
        }

        private int GetPrecedence(string op)
        {
            if (op == "^") return 3;
            if (op == "*") return 2;
            if (op == "/") return 2;
            if (op == "+") return 1;
            if (op == "-") return 1;

            if (op == "S") return 1; //Sin
            if (op == "C") return 1; //Cos
            if (op == "T") return 1; //Tan

            if (op == "I") return 1; //Csc
            if (op == "O") return 1; //Sec
            if (op == "A") return 1; //Cot

            throw new Exception("This is NOT a valid operator.");
        }
    }
}
