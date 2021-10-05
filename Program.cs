using System;
using System.Collections.Generic;

namespace HomeTask_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom polynom = new Polynom();

            polynom=Polynom.Parse("2X^3-3X^2+2.3X^4");

            Console.WriteLine(polynom);
        }
    }
}
