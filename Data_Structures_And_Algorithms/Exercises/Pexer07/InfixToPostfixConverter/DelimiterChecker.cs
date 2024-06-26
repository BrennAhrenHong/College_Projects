using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace InfixToPostfixConverter
{
    public class DelimiterChecker
    {
        public bool HasMatchingDelimiter(string expression)
        {
            var delimiterStack = new Stack<char>();

            foreach (var ch in expression)
            {
                if(IsOpeningDelimeter(ch.ToString()))
                    delimiterStack.Push(ch);
                else if (IsClosingDelimeter(ch.ToString()))
                {
                    if (delimiterStack.Count < 0) return false;

                    char pair = delimiterStack.Pop();
                    if (!IsMatchingPair(pair, ch)) return false;
                }
            }

            return delimiterStack.Count <= 0;
        }

        private static bool IsMatchingPair(char opening, char closing)
        {
            if (opening == '(' && closing == ')')
                return true;
            else if (opening == '[' && closing == ']')
                return true;
            else if (opening == '{' && closing == '}')
                return true;
            else
                return false;
        }
        public bool IsOpeningDelimeter(string ch)
        {
            return ch == "(" || ch == "[" || ch == "{";
        }

        public bool IsClosingDelimeter(string ch)
        {
            return ch == ")" || ch == "]" || ch == "}";
        }

    }
}
