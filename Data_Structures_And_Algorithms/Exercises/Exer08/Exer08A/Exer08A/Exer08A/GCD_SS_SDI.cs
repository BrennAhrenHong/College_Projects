using System;
using System.Diagnostics.CodeAnalysis;

namespace Exer08A
{
    public class GCD_SS_SDI
    {
        public void Gcd(int m, int n)
        {
            int result = m % n;
            if (result == 0)
                Console.WriteLine(n);
            else
                Gcd(n, result);
        }

        private float ss_Sum = 0;
        public float SummingSeries(int i)
        {
            float denominator = 2 * i + 1; ;
            float result = i / denominator;
            if (i != 0)
            {
                Console.WriteLine(i + "/" + denominator);
                ss_Sum = ss_Sum + result + SummingSeries(i-1);
            }

            return ss_Sum;
        }

        private int sum = 0;
        public int SumofIntegers(string input)
        {
            if (input.Substring(1) != "")
            {
                sum = sum + Convert.ToInt32(input[0].ToString()) + SumofIntegers(input.Substring(1));
            }
            else
                sum = sum + Convert.ToInt32((input[0].ToString()));

            return sum;
        }
    }
}
