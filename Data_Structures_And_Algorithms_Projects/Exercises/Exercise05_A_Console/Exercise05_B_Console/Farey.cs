using ILinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise05_B_Console
{
    public class Farey
    {
        public Farey(int n)
        {
            Nlevel = n;
        }

        private ILinkedList<Fraction> _fractions;
        public int Nlevel { get; private set; }

        public ILinkedList<Fraction> Fractions => _fractions;

        private ILinkedList<Fraction> CreateFareyFractions(int level)
        {
            var tmpList = new GenericDoublyLinkedList<Fraction>();

            tmpList.AddToHead( new Fraction(0,1));
            tmpList.AddToHead( new Fraction(1,1));

            if (level == 1) return tmpList;

            Node<Fraction> prev;
            Node<Fraction> next;

            prev = tmpList.Head;


            return null;
        }
    }
}
