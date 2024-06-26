using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ILinkedList;

namespace Exercise05_A_Console
{
    class GiantInt
    {
        public GiantInt(string numberString)
        {
            Numbers = ParseInput(numberString);
        }

        public GiantInt(string[] numberStringArray)
        {
            Numbers = ParseInput(numberStringArray);
        }

        public ILinkedList<int> Numbers { get; }

        public GiantInt Add(GiantInt itemToAdd)
        {
            int carryNumber = 0;

            var firstNumber = Numbers.Tail;
            var secondNumber = itemToAdd.Numbers.Tail;
            var sum = new GenericDoublyLinkedList<int>();
            string endSum = "";

            while (firstNumber != null && secondNumber != null && firstNumber.Data != 0 && secondNumber.Data != 0)
            {
                var tmpSum = firstNumber.Data + secondNumber.Data;
                sum.AddToHead((tmpSum + carryNumber) % 1000);
                carryNumber = (int) (tmpSum / 1000);

                if (firstNumber.Prev != null)
                    firstNumber = firstNumber.Prev;
                else firstNumber.Data = 0;

                if (secondNumber.Prev != null)
                    secondNumber = secondNumber.Prev;
                else secondNumber.Data = 0;
            }

            foreach (var item in sum)
            {
                endSum += item;
            }

            var sumGiantInt = new GiantInt(endSum);
            return sumGiantInt;
        }

        public GiantInt Subtract(GiantInt itemToAdd)
        {
            string firstNumber = "";
            string secondNumber = "";

            foreach (var item in Numbers)
            {
                if (item.ToString().Length < 3)
                {
                    for (int i = 3 - item.ToString().Length; i != 0; i--)
                    {
                        firstNumber += "0";
                    }

                    firstNumber += item;
                }
                else
                    firstNumber += item;

            }
            foreach (var item in itemToAdd.Numbers)
            {
                if (item.ToString().Length < 3)
                {
                    for (int i = 3 - item.ToString().Length; i != 0; i--)
                    {
                        secondNumber += "0";
                    }

                    secondNumber += item;
                }
                else
                    secondNumber += item;
            }

            int difference = Convert.ToInt32(firstNumber) - Convert.ToInt32(secondNumber);

            var differenceGiantInt = new GiantInt(difference.ToString());

            return differenceGiantInt;
        }

        public GiantInt Multiply(GiantInt itemToAdd)
        {
            string firstNumber = "";
            string secondNumber = "";

            foreach (var item in Numbers)
            {
                if (item.ToString().Length < 3)
                {
                    for (int i = 3 - item.ToString().Length; i != 0; i--)
                    {
                        firstNumber += "0";
                    }

                    firstNumber += item;
                }
                else
                    firstNumber += item;

            }
            foreach (var item in itemToAdd.Numbers)
            {
                if (item.ToString().Length < 3)
                {
                    for (int i = 3 - item.ToString().Length; i != 0; i--)
                    {
                        secondNumber += "0";
                    }

                    secondNumber += item;
                }
                else
                    secondNumber += item;
            }

            int product = Convert.ToInt32(firstNumber) * Convert.ToInt32(secondNumber);

            var productGiantInt = new GiantInt(product.ToString());

            return productGiantInt;
        }

        #region Private Methods

        private ILinkedList<int> ParseInput(string[] numbers)
        {
            var list = new GenericDoublyLinkedList<int>();
            foreach (string item in numbers)
            {
                int parsed = int.Parse(item);
                if (Math.Abs(parsed).ToString().Length > 3)
                    throw new InvalidOperationException("The length ");
                list.AddToTail(int.Parse(item));
            }

            return list;
        }

        private ILinkedList<int> ParseInput(string numberInputString)
        {
            if (!numberInputString.Contains(",")) numberInputString = ProcessString(numberInputString);

            var combinedNumbers = numberInputString.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return ParseInput(combinedNumbers);
        }

        private string ProcessString(string numberString)
        {
            bool isNegative = false;
            if (numberString.StartsWith("-"))
            {
                isNegative = true;
                numberString = numberString.Remove(0, 1); // #A
            }

            if (numberString.Length <= 3)
            {
                if (isNegative) return "-" + numberString; // #B
                return numberString;
            }

            var sb = new StringBuilder(numberString);
            for (int i = numberString.Length - 3; i > 0; i -= 3) sb.Insert(i, ",");

            if (isNegative) sb.Insert(0, "-"); // #B
            return sb.ToString();
        }
        

        #endregion

    }
}
