using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_IronPython
{
    class Program
    {
        static void Main(string[] args)
        {
            //instance of python engine
            var engine = Python.CreateEngine();
            //reading code from file
            var source = engine.CreateScriptSourceFromFile
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "PythonSampleIronPython.py"));
            var scope = engine.CreateScope();
            //executing script in scope
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            //initializing class
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            Console.WriteLine("From Iron Python");
            Console.WriteLine("5 + 10 = {0}", calculatorInstance.add(5, 10));
            Console.WriteLine("5++ = {0}", calculatorInstance.increment(5));
            Console.ReadLine();
        }
    }
}
