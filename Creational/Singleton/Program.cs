using System;

namespace Singleton
{
    sealed class Singleton
    {
        private static Singleton _instance;
        private static readonly object LockObject = new object();

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

            Console.WriteLine(singleton1 == singleton2);
        }
    }
}