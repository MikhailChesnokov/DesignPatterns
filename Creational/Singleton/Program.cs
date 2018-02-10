using System;

namespace Creational.Singleton
{
    sealed class Singleton
    {
        private static readonly object LockObject = new object();
        
        private static Singleton _instance;

        
        private Singleton() { }

        public static Singleton Instance()
        {
            if (_instance != null) return _instance;

            lock (LockObject)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }
    }

    class Program
    {
        static void Main()
        {
            Singleton singleton1 = Singleton.Instance();
            Singleton singleton2 = Singleton.Instance();

            Console.WriteLine("The singleton1 instance is equal to singleton2 instance: " + (singleton1 == singleton2));
        }
    }
}