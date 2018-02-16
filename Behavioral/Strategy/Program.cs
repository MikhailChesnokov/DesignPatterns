using System;
using System.Linq;

namespace Behavioral.Strategy
{
    interface IStrategy
    {
        void AlgorithmInterface(Context context);
    }

    class ConcreteStrategyA : IStrategy
    {
        public void AlgorithmInterface(Context context) // Find index of 'W' using IndexOf()
        {
            Console.WriteLine("The index of \'W\' = " + context.Text.IndexOf("W", StringComparison.Ordinal));
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void AlgorithmInterface(Context context) // Find index of 'W' using Ling
        {
            Console.WriteLine("The index of \'W\' = " + context.Text.ToCharArray().TakeWhile(ch => ch != 'W').Count());
        }
    }

    class ConcreteStrategyC : IStrategy
    {
        public void AlgorithmInterface(Context context) // Find index of 'W' using custom algorithm
        {
            int i = 0;

            while (context.Text[i] != 'W')
            {
                i++;
            }

            Console.WriteLine("The index of \'W\' = " + i);
        }
    }

    class Context
    {
        protected IStrategy Strategy;

        public string Text { get; } = "Hello, World!";

        public void SetStrategy(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public void ContextInterface()
        {
            Strategy.AlgorithmInterface(this);
        }
    }

    class Program
    {
        static void Main()
        {
            IStrategy[] strategies =
            {
                new ConcreteStrategyA(),
                new ConcreteStrategyB(),
                new ConcreteStrategyC()
            };

            Context context = new Context();

            foreach (IStrategy strategy in strategies)
            {
                context.SetStrategy(strategy);

                context.ContextInterface();
            }
        }
    }
}