using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CS_ConcurrentBag_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConcurrencyBagSample concurrencyBagSample = new ConcurrencyBagSample();
            //concurrencyBagSample.DemoConcurrentBag();

            //ListSample listSample = new ListSample();
            //listSample.DemoList();
            Demo d = new Demo();
            //var t1 = Task.Factory.StartNew(() => { d.AddData();});
            //var t2 = Task.Factory.StartNew(() => { d.PrintData(); });

            //t1.Wait();
            //t2.Wait();
            var threadStart1 = new ThreadStart(d.AddData);
            Thread thread1 = new Thread(threadStart1);
            var threadStart2 = new ThreadStart(d.PrintData);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();
            thread1.Start();
           
            Console.ReadLine();
        }
    }


    public class Demo
    {
         List<int> lstInt = new List<int>();
        //ConcurrentBag<int> lstInt = new ConcurrentBag<int>();

        public void AddData()
        {
            for (int i = 0; i < 10; i++)
            {
                lstInt.Add(i);
    //            Console.WriteLine(i);
            }
        }

        public void PrintData()
        {
            for (int i = 0; i < 10; i++)
            {
                // Console.WriteLine(lstInt.TryTake(out i));
                 Console.WriteLine(JsonSerializer.Serialize(lstInt));
                //Console.WriteLine(lstInt[i]);
               // Console.WriteLine($"Reading {i}");
            }
        }



    }


    public class ConcurrencyBagSample
    {
        delegate void myDelegate(string strParam);
        public void DemoConcurrentBag()
        {
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

            //Single thread fills the data
            for (int i = 1; i <= 10; i++)
            {
                concurrentBag.Add(i);
            }

            Action runMethod = () =>
            {
                while (true)
                {

                    int result; if (concurrentBag.TryTake(out result))
                        Console.WriteLine("This isThread = {0} accessing " +
                          "concurrentbag value = {1} ",
                          Thread.CurrentThread.Name, result);
                }
            };

            Thread thread1 = new Thread(new ThreadStart(runMethod));
            thread1.Name = "Thread1";
            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(runMethod));
            thread2.Name = "Thread2";
            thread2.Start();

            Thread thread3 = new Thread(new ThreadStart(runMethod));
            thread3.Name = "Thread3";
            thread3.Start();

            Thread.CurrentThread.Join();


        }
    }


    public class ListSample
    {
        delegate void myDelegate(string strParam);
        public void DemoList()
        {
            List<int> list = new List<int>();

            //Single thread fills the data
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }

            Action runMethod = () =>
            {
                while (true)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine("This isThread = {0} accessing " +
                         "concurrentbag value = {1} ",
                         Thread.CurrentThread.Name, item);
                    }

                }
            };

            Thread thread1 = new Thread(new ThreadStart(runMethod));
            thread1.Name = "Thread1";
            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(runMethod));
            thread2.Name = "Thread2";
            thread2.Start();

            Thread thread3 = new Thread(new ThreadStart(runMethod));
            thread3.Name = "Thread3";
            thread3.Start();

            Thread.CurrentThread.Join();


        }
    }
}
