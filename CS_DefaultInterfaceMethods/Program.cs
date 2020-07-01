using System;

namespace CS_DefaultInterfaceMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            IFile xFile = new XmlFile();
            xFile.CreateFile("f.xml");
            xFile.WriteFile("f.xml");

            IFile tFile = new TextFile();

            tFile.CreateFile("t.txt");
            tFile.WriteFile("t.txt");

            I1 i1 = new MultiIntyerfaceClass();
            I2 i2 = new MultiIntyerfaceClass();

            i1.DoWork();
            i2.DoWork();


            Console.ReadLine();
        }
    }

    public interface IFile
    {
        public void CreateFile(string fileName)
        {
            Console.WriteLine($"The File is created {fileName}");
        }

        public void WriteFile(string fileName);
    }


    public class XmlFile : IFile
    {
        public void CreateFile(string fileName)
        {
            Console.WriteLine($"The File is create{fileName}");
        }
        public void WriteFile(string fileName)
        {
            Console.WriteLine($"The File is Written {fileName}");
        }
    }

    public class TextFile : IFile
    {
        void IFile.CreateFile(string fileName)
        {
            Console.WriteLine($"The Text File is Created{fileName}");
        }
        void IFile.WriteFile(string fileName)
        {
            Console.WriteLine($"The Text File is Written {fileName}");
        }
    }



    public interface I1
    {
        public void DoWork()
        {
            Console.WriteLine("Work done I1");
        }
    }

    public interface I2
    {
        public void DoWork()
        {
            Console.WriteLine("Work done I2");
        }
    }

    public class MultiIntyerfaceClass : I1, I2 { }

}
