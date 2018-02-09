using System;

namespace Structural.Decorator
{
    interface IComponent
    {
        void Operation();
    }

    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.Write("World!");
        }
    }

    abstract class Decorator : IComponent
    {
        protected IComponent Component { get; }

        protected Decorator(IComponent component)
        {
            Component = component;
        }

        public virtual void Operation()
        {
            Component.Operation();
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component)
            : base(component) { }

        public override void Operation()
        {
            Console.Write(", ");

            base.Operation();
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component)
            : base(component) { }

        public override void Operation()
        {
            Console.Write("Hello");

            base.Operation();
        }
    }

    static class Program
    {
        static void Main()
        {
            Decorator decorator = new ConcreteDecoratorA(new ConcreteDecoratorB(new ConcreteComponent()));

            decorator.Operation(); // Hello, World!
        }
    }
}