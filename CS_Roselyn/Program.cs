using Microsoft.CodeAnalysis.CSharp;
using RoslynCore;
using System;

namespace CS_Roselyn
{
    class Program    
    {
        static void Main(string[] args)
        {
            GenerateSampleViewModel();
        }
        static void GenerateSampleViewModel()
        {
            const string models = @"namespace Models
{
  public class Item
  {
    public string ItemName { get; set }
  }
}
";
            var node = CSharpSyntaxTree.ParseText(models).GetRoot();
            Console.WriteLine(node.ToFullString());
           
            //var viewModel = ViewModelGeneration.GenerateViewModel(node);
            //if (viewModel != null)
            //    Console.WriteLine(viewModel.ToFullString());
            Console.ReadLine();
        }
    }


  
}
