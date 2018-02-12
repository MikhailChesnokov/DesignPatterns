using System;

namespace Structural.Bridge
{
    abstract class Abstraction
    {
        private readonly IImplementor _implementor;

        protected Abstraction(IImplementor implementor)
        {
            _implementor = implementor;
        }

        protected void Operation(string message)
        {
            _implementor.OperationImp(message);
        }
    }

    interface IRefinedAbstraction
    {
        void UseOperation();
    }

    class RefinedAbstraction1 : Abstraction, IRefinedAbstraction
    {
        public RefinedAbstraction1(IImplementor implementor) : base(implementor) { }

        public void UseOperation() // greeting one
        {
            Operation("Hello, World!");
        }
    }

    class RefinedAbstraction2 : Abstraction, IRefinedAbstraction
    {
        public RefinedAbstraction2(IImplementor implementor) : base(implementor) { }

        public void UseOperation() // greeting two
        {
            Operation("What's up, World?");
        }
    }

    interface IImplementor
    {
        void OperationImp(string message);
    }

    class ConcreteImplementorA : IImplementor
    {
        public void OperationImp(string message) // json message printer
        {
            Console.WriteLine($"{{ \"message\" : \"{message}\" }}");
        }
    }

    class ConcreteImplementorB : IImplementor
    {
        public void OperationImp(string message) // xml message printer
        {
            Console.WriteLine($"<message>{message}</message>");
        }
    }

    class Program
    {
        static void Main()
        {
            IImplementor[] implementors =
            {
                new ConcreteImplementorA(),
                new ConcreteImplementorB()
            };

            foreach (IImplementor implementor in implementors)
            {
                IRefinedAbstraction abstraction1 = new RefinedAbstraction1(implementor);

                abstraction1.UseOperation();


                IRefinedAbstraction abstraction2 = new RefinedAbstraction2(implementor);

                abstraction2.UseOperation();
            }
        }
    }
}