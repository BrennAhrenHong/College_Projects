using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var sl = new SinglyLinkedList();
            //sl.AddToHead("C");
            //sl.AddToHead("B");
            //sl.AddToHead("A");
            sl.AddToTail("A");
            sl.AddToTail("B");
            sl.AddToTail("C");
            sl.AddToTail("D");
            sl.AddToTail("E");
            sl.SwapHeadAndTail();




            //Console.WriteLine(sl.Count);
            //sl.DeleteFromPosition(4);

            Console.WriteLine();

            foreach (var link in sl)
            {
                Console.WriteLine(link);
            }

            Console.ReadLine();
            Console.WriteLine(sl.Count);
            //Console.WriteLine(sl.Head.Next.Next.Data);


            Console.ReadLine();

                    
        }
    }
}
