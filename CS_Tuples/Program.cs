using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CS_Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un-Named tuples
            var unnamed = ("Mahesh", "Rameshrao", "Sabnis");
            Console.WriteLine($"Unnamed Tuple Values \n {unnamed.Item1} {unnamed.Item3} {unnamed.Item2}");
            // named tuples
            // names will not be displayed in MSIL
            // but using Roslyn APIs the tuple names will be shown in IDE
            // compiler will replacve these names using Item* standard 
            var named = (firstName: "Mahesh", middleName: "Rameshrao", lastName:"Sabnis");
            Console.WriteLine($"Named Tuple values \n {named.firstName} {named.middleName} {named.lastName}");

            // typle projection initializers
            // Beginning with C# 7.1, the field names for a tuple may be provided from 
            //the variables used to initialize the tuple.

            var fullName = "Mahesh Rameshrao Sabnis";
            var age = 43;
            var occupation = "Self-Employed";

            var personDetails = (fullName, age, occupation);
            Console.WriteLine($"Person Details \n {personDetails.fullName} " +
                $" {personDetails.age} {personDetails.occupation}");

            Tuple<string, int, string> tp = new Tuple<string, int, string>(fullName, age, occupation);
            Console.WriteLine($"Type of tp = {tp.GetType()}");
            Console.WriteLine($"Type of personDetails = {personDetails.GetType()}" +
                $" String Representation {personDetails.ToString()}" );

            // this will return false
            Console.WriteLine(personDetails.Equals(tp));


            var tp1 = (fullName, age, occupation);
            occupation = "Employed";
            var tp2 = (fullName, age, occupation);
            Console.WriteLine(tp1.Equals(tp2)); // will return false because occupation is changed



            var t0 = (10, 20);
            var t1 = (10, 20);
            Console.WriteLine(t0 == t1); // true
            var t2 = (20, 10);
            Console.WriteLine(t0 == t2); // false
            var t3 = (20, i: 10);
            Console.WriteLine(t2 == t3); // true

            (int a, string b) t4 = (10, "ABC");
            (int a, string b) t5 = (10, "ABC");
            Console.WriteLine(t4 == t5); // true member names will not be considered

            Console.WriteLine(t4 == (a:10, b:"ABC")); // true

            Console.WriteLine($"All data of completed tasks {JsonSerializer.Serialize(GetCompletedTasks())}");
            Console.WriteLine();
            Console.WriteLine($"All data of completed tasks using tuples " +
                $"{GetCompletedTasksWithTuples()}");

            List<(string, string)> Res = GetCompletedTasksWithTuples();
            Console.WriteLine($" {Res[0].Item1} {Res[0].Item2} ");
            Console.ReadLine();
        }


        static IEnumerable<ProjectTask> GetCompletedTasks()
        {
            var projectsTasks = new ProjectTasks();
            IEnumerable<ProjectTask> tasks = null;
            tasks = from t in projectsTasks
                    where t.Status == true
                    select t;
            return tasks;
        }


        static List<(string AssignTo, string TaskName)> GetCompletedTasksWithTuples()
        {
            var projectsTasks = new ProjectTasks();
             
            var res = from t in projectsTasks
                    where t.Status == true
                    select (t.AssignTo, t.TaskName);
            return res.ToList();
        }


    }
}
