using System;
using System.Collections.Generic;

namespace Structural.Proxy
{
    interface ISubject
    {
        int Request(int value);
    }

    class RealSubject : ISubject // Simple slow factorial calculator
    {
        public int Request(int value)
        {
            return value == 1 ? 1 : value * Request(value - 1);
        }
    }

    class Proxy : ISubject  // Simple slow factorial calculator with cache
    {
        private readonly Dictionary<int, int> _factorialCache = new Dictionary<int, int>();

        protected readonly RealSubject RealSubject = new RealSubject();

        public int Request(int value)
        {
            if (_factorialCache.TryGetValue(value, out int cachedValue))
            {
                Console.Write("Cached: ");
                return cachedValue;
            }

            _factorialCache[value] = RealSubject.Request(value);

            
            Console.Write("Calculated: ");
            return _factorialCache[value];
        }
    }

    class Program
    {
        static void Main()
        {
            ISubject subject = new Proxy();

            Console.WriteLine(subject.Request(5)); // Calculated: 120
            Console.WriteLine(subject.Request(5)); // Cached: 120
        }
    }
}