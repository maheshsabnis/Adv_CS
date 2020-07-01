using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CS_OutVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            // earlier we used to declare
            //int x, y;
            //XChange(out x,out y);

            XChange(out int x, out int y);
            Console.WriteLine($"x = {x} y = {y}");
            Console.ReadLine();
        }

        static void XChange(out int x, out int y)
        {
            x = 30; y = 10;
            var z = x;
            x = y;
            y = z;
        }

    }
}
