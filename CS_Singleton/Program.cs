using System;

namespace CS_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = Singleton.Instance;
            var s2 = Singleton.Instance;
            if (s1 == s2) Console.WriteLine("They are Equal Object s1 and s2");
            Console.WriteLine();
            if (s1.Equals(s2)) Console.WriteLine("Objects are Equal s1 and s2");

            Console.WriteLine();
            Console.WriteLine("Thread Safe");

            var s11 = SingletonThreadSafe.Instance;
            var s12 = SingletonThreadSafe.Instance;
            if (s11 == s12) Console.WriteLine("They are Equal Object s11 s12");
            Console.WriteLine();
            if (s11.Equals(s12)) Console.WriteLine("Objects are Equal s11 s12");
            Console.WriteLine();
            Console.WriteLine("Thread Safe Double Check");
            var s21 = SingletonThreadSafeDoubleLockCheck.Instance;
            var s22 = SingletonThreadSafeDoubleLockCheck.Instance;
            if (s21 == s22) Console.WriteLine("They are Equal Object s21 s22");
            Console.WriteLine();
            if (s21.Equals(s22)) Console.WriteLine("Objects are Equal s21 s22");

            Console.WriteLine();
            Console.WriteLine("C# 4.0 using Lazy");

            var s31 = SingletonLazy.Instance;
            var s32 = SingletonLazy.Instance;
            if (s31 == s32) Console.WriteLine("They are Equal Object s31 s32");
            Console.WriteLine();
            if (s31.Equals(s32)) Console.WriteLine("Objects are Equal s31 s32");

            Console.ReadLine();
        }
    }

    // No Thread Safe Singleton
    // Bad code! Do not use it!  
    public sealed class Singleton
    {
        //Private Constructor.  
        private Singleton()
        {
        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    // Thread Safety Singleton
    public sealed class SingletonThreadSafe
    {
        SingletonThreadSafe()
        {
        }
        private static readonly object padlock = new object();
        private static SingletonThreadSafe instance = null;
        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonThreadSafe();
                    }
                    return instance;
                }
            }
        }
    }

    // Thread Safety Singleton using Double Check Locking
    public sealed class SingletonThreadSafeDoubleLockCheck
    {
        SingletonThreadSafeDoubleLockCheck()
        {
        }
        private static readonly object padlock = new object();
        private static SingletonThreadSafeDoubleLockCheck instance = null;
        public static SingletonThreadSafeDoubleLockCheck Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonThreadSafeDoubleLockCheck();
                        }
                    }
                }
                return instance;
            }
        }
    }

    // Using .NET 4's Lazy<T> type
    // All you need to do is pass a delegate to the constructor 
    // that calls the Singleton constructor, 
    // which is done most easily with a lambda expression.
    public sealed class SingletonLazy
    {
        private SingletonLazy()
        {
        }
        private static readonly Lazy<SingletonLazy> lazy =
            new Lazy<SingletonLazy>(() => new SingletonLazy());
        public static SingletonLazy Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
