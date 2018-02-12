using System;

namespace Structural.Adapter
{
    class Adaptee1
    {
        public void SpecificRequest1()
        {
            Console.Write("Hello");
        }

        public void SpecificRequest2()
        {
            Console.Write(", ");
        }

        public void SpecificRequest3()
        {
            Console.WriteLine("World!");
        }
    }

    class Adaptee2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("hello, World!");
        }
    }

    interface ITarget
    {
        void Request();
    }
    
    sealed class Adapter1 : ITarget
    {
        private readonly Adaptee1 _adaptee = new Adaptee1();

        public void Request()
        {
            _adaptee.SpecificRequest1();
            _adaptee.SpecificRequest2();
            _adaptee.SpecificRequest3();
        }
    }

    sealed class Adapter2 : ITarget
    {
        private readonly Adaptee2 _adaptee = new Adaptee2();

        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    class Program
    {
        static void Main()
        {
            ITarget[] targets =
            {
                new Adapter1(),
                new Adapter2()
            };

            foreach (ITarget target in targets)
            {
                Console.Write("From " + target.GetType().Name + " :");

                target.Request(); // Hello, World!
            }
        }
    }
}