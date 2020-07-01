using System;
using System.Collections.Generic;

namespace CS_PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            PatternTypeCheck(100);
            PatternTypeCheck("Mr.");

            List<object> values = new List<object>()
            {
                10,20,"Mahesh", "Sabnis", 40,50,90.8, "Tejas",
                80.2, 56.34, "Leena", true, false, null,
                "Rameshrao", 76.55, 30,70, -9, 
                new List<int>() {40,32,46,70 },
                new List<string> () { "Mrs.", "Leena", "Sabnis"},
                -8
            };

            SwitchCasePatternMatching(values);

            Console.ReadLine();
        }

        static void PatternTypeCheck(object value)
        {
            if (value is int v) {
                v = 100;
                Console.WriteLine($"Integer Pattern {Convert.ToInt32(value) + v}");
            }
            if (value is string s)
            {
                s = "Mahesh Sabnis";
                Console.WriteLine($"String Pattern {value + s}");
            }
        }
        static void SwitchCasePatternMatching(IEnumerable<object> values)
        {
            int intSum = 0;
            string stringConcat = "";
            double doubleSum = 0;
            foreach (var item in values)
            {
                try
                {
                    switch (item)
                    {
                        case 0:
                            break;
                        case IEnumerable<int> intValues:
                            {
                                foreach (var intValue in intValues)
                                {
                                    intSum += intValue;
                                }
                                break;
                            }
                        case IEnumerable<string> stringValues:
                            {
                                foreach (var stringValue in stringValues)
                                {
                                    stringConcat += stringValue;
                                }
                                break;
                            }
                        case IEnumerable<double> doubleValues:
                            {
                                foreach (var doubleValue in doubleValues)
                                {
                                    doubleSum += doubleValue;
                                }
                                break;
                            }
                        case int v when v > 0:
                            intSum += v;
                            break;
                        case int v when v < 0:
                            Console.WriteLine($"Found -Ve Value {v}");
                            break;
                        case string str:
                            {
                                stringConcat += str;
                                break;
                            }
                        case double d: 
                            {
                                doubleSum += d;
                                break;
                            }
                        case null:
                            Console.WriteLine("NULL Value is present in input data");
                            throw new NullReferenceException("NULL Value is present in input data");
                        default:
                            throw new InvalidOperationException("Unrecognized type");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception is thrown {ex.Message}");
                }
            }

            Console.WriteLine($"Interger values sum {intSum}");
            Console.WriteLine($"Double values sum {doubleSum}");
            Console.WriteLine($"String values concatination {stringConcat}");
        }

    }


}
