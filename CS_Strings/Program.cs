using System;
using System.Globalization;
using System.Text.Json;

namespace CS_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Mahesh Ramesh Sabnis";
            var _ = str.Split(' ');
            Console.WriteLine($"{_[0]} {_[1]} {_[2]}");

            var ts1 = str.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(ts1[0]);


            var ts2 = str.Split(' ', StringSplitOptions.None);
            Console.WriteLine(JsonSerializer.Serialize(ts2));

            var s1 = "AMahesh";
            var s2 = "AMahesh Sabnis";

            int comparision = String.Compare(s1, s2);

            Console.WriteLine($"Comparision Result {comparision}");

            string author1 = "Mahesh Sabnis";
            string author2 = "Dabade Praveen ";

            // Use String.Compare method  
            if (String.Compare(author1, author2) == 0)
                Console.WriteLine($"Both strings have same value.");
            else if (String.Compare(author1, author2) < 0)
                Console.WriteLine($"{author1} precedes {author2}.");
            else if (String.Compare(author1, author2) > 0)
                Console.WriteLine($"{author1} follows {author2}.");

            string dateInput = "Jan 1, 2020";
            var parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(parsedDate);

           // var cultureInfo = new CultureInfo("de-DE");
            var cultureInfo = new CultureInfo("hi-IN");

            //string dateString = "12 Juni 2008";
            string dateString = "12 Jun 2020";

            var dateTime = DateTime.Parse(dateString, cultureInfo);
            Console.WriteLine(dateTime);

            Console.ReadLine();
        }
    }





}
