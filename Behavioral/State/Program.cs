using System;

namespace Behavioral.State
{
    interface IState
    {
        void Handle(Context context);
    }

    sealed class ConcreteStateA : IState
    {
        private static readonly ConcreteStateA StateA = new ConcreteStateA();

        private ConcreteStateA() { }

        public static IState Instance => StateA;

        public void Handle(Context context)
        {
            Console.WriteLine("A -> B");

            context.ChangeState(ConcreteStateB.Instance);
        }
    }

    sealed class ConcreteStateB : IState
    {
        private static readonly ConcreteStateB StateB = new ConcreteStateB();

        private ConcreteStateB() { }

        public static IState Instance => StateB;

        public void Handle(Context context)
        {
            Console.WriteLine("B -> A");

            context.ChangeState(ConcreteStateA.Instance);
        }
    }

    class Context
    {
        protected IState State;

        public Context(IState initialState)
        {
            State = initialState;
        }

        public void ChangeState(IState state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }

    class Program
    {
        static void Main()
        {
            Context context = new Context(initialState: ConcreteStateA.Instance);

            context.Request(); // A -> B
            context.Request(); // B -> A
            context.Request(); // A -> B
        }
    }
}