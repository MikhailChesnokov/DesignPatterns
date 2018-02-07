using static System.Console;

namespace Structural.Decorator
{
    internal interface IComponent
    {
        void Operation();
    }

    internal class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Write("World!");
        }
    }

    internal abstract class Decorator : IComponent
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

    internal class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component)
            : base(component) { }

        public override void Operation()
        {
            Write(", ");

            base.Operation();
        }
    }

    internal class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component)
            : base(component) { }

        public override void Operation()
        {
            Write("Hello");

            base.Operation();
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            Decorator decorator = new ConcreteDecoratorA(new ConcreteDecoratorB(new ConcreteComponent()));

            decorator.Operation();
        }
    }
}