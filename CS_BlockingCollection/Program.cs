using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CS_BlockingCollection
{
    class Program
    {
        // This collection is mainly used for adding and removing data.

      //  Removing an item from the collection can be blocked until data becomes available.

      //  Adding data is fast, but you can set a maximum  
      //upper limit.If that limit is reached, adding an item blocks the calling  
      //thread until there is room.

     //   BlockingCollection is actually a wrapper around other collection types. 
     //If you don’t give it any specific instructions, it uses the ConcurrentQueue by default.
        static void Main(string[] args)
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });
            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();
            Console.ReadLine();
        }
    }
}
