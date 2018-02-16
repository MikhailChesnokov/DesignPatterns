using System;

namespace Behavioral.Command
{
    interface IReceiver
    {
        void Action();
    }

    class ConcreteReceiver : IReceiver
    {
        public void Action()
        {
            Console.WriteLine("Action");
        }
    }

    interface ICommand
    {
        void Execute();
    }

    class ConcreteCommand1 : ICommand
    {
        private readonly IReceiver _receiver;

        public ConcreteCommand1(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }
    }

    class Invoker
    {
        private readonly ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    class Program
    {
        static void Main()
        {
            IReceiver receiver = new ConcreteReceiver();

            ICommand command = new ConcreteCommand1(receiver);

            Invoker invoker = new Invoker(command);

            invoker.ExecuteCommand();
        }
    }
}