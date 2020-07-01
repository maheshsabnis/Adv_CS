using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CS_Ref_Return_Ref_Local
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.GetAndUpdateAddress();
            Console.ReadLine();
        }
    }



    public struct MyAddress
    {
        public string FlatNo;
        public string SocietyName;
        public string StreetName;
        public string City;
    }

    public class PersonInfo
    {
        public ref MyAddress GetFirstAddress(MyAddress [] myAddresses)
        {
            return ref myAddresses[0];
        }
    }

    /// <summary>
    /// Old client
    /// </summary>
    //public class Client
    //{
    //    public void GetAndUpdateAddress()
    //    {
    //        var person = new PersonInfo();
    //        var addresses = new[] {
    //            new MyAddress{ 
    //                 City = "Pune"
    //            }
    //        };
    //        // this always return value for City
    //        MyAddress address = person.GetFirstAddress(addresses);

    //        // change the City
    //        address.City = "Pune Bavdhan";
    //        // Print
    //        Console.WriteLine(addresses[0].City);
    //    }
    //}


    public class Client
    {
        public void GetAndUpdateAddress()
        {
            var person = new PersonInfo();
            var addresses = new[] {
                new MyAddress{
                     City = "Pune"
                }
            };
            // this will update the value
            ref MyAddress address = ref person.GetFirstAddress(addresses);

            // change the City
            address.City = "Pune Bavdhan";
            // Print
            Console.WriteLine(addresses[0].City);
        }
    }
}
