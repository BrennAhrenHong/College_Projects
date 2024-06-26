using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise05_B_Console
{
    public class Fraction : IComparable<Fraction>
    {
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public int CompareTo(Fraction other)
        {
            if (other.Denominator == Denominator && other.Numerator == Numerator)
                return 0;
            return -1;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Numerator.ToString());
            sb.AppendLine("—");
            sb.AppendLine(Denominator.ToString());
            return sb.ToString();
        }
    }
}
