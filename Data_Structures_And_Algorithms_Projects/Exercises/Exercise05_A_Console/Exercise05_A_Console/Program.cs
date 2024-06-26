using System;

namespace Exercise05_A_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new GiantInt("2,147,483,647");
            var y = new GiantInt("1");

            var z = x.Add(y);

            foreach (var item in z.Numbers)
            {
                Console.Write(item);
            }
            Console.ReadLine();


        }
    }
}
