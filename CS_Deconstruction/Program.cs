using System;

namespace CS_Deconstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            var (fname, lname) = ("Mahesh", "Sanis");
            Console.WriteLine(fname + "  " + lname );
            Console.ReadLine();
        }
    }

     
}
