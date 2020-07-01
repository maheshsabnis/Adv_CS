using System;

namespace CS_Discards
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ = Add(200, 300);
            Console.WriteLine(_);
            Console.ReadLine();
        }


        static int Add(int x, int y)
        {
             
            var _ = x + y;
            var r = _;
            return _;
        }
    }
}
