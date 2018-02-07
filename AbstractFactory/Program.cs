using static System.Console;

namespace Structural.AbstractFactory
{
    internal interface IAbstractFactory
    {
        IAbsractProbuctA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    internal interface IAbsractProbuctA
    {   
        void Interact(IAbstractProductB productB);
    }

    internal interface IAbstractProductB
    {
        void Interact(IAbsractProbuctA probuctA);
    }

    internal class ConcreteProbuctA1 : IAbsractProbuctA
    {
        public void Interact(IAbstractProductB productB)
        {
            WriteLine("The instance of " + typeof(ConcreteProbuctA1).Name + " is interacting with the instance of " + productB.GetType().Name);
        }
    }

    internal class ConcreteProductA2 : IAbsractProbuctA
    {
        public void Interact(IAbstractProductB productB)
        {
            WriteLine("The instance of " + typeof(ConcreteProductA2).Name + " is interacting with the instance of " + productB.GetType().Name);
        }
    }

    internal class ConcreteProductB1 : IAbstractProductB
    {
        public void Interact(IAbsractProbuctA probuctA)
        {
            WriteLine("The instance of " + typeof(ConcreteProductB1).Name + " is interacting with the instance of " + probuctA.GetType().Name);
        }
    }

    internal class ConcreteProductB2 : IAbstractProductB
    {
        public void Interact(IAbsractProbuctA probuctA)
        {
            WriteLine("The instance of " + typeof(ConcreteProductB2).Name + " is interacting with the instance of " + probuctA.GetType().Name);
        }
    }

    internal class ConcreteFactory1 : IAbstractFactory
    {
        public IAbsractProbuctA CreateProductA()
        {
            return new ConcreteProbuctA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    internal class ConcreteFactory2 : IAbstractFactory
    {
        public IAbsractProbuctA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    internal class Client
    {
        private readonly IAbsractProbuctA _probuctA;
        private readonly IAbstractProductB _productB;
        
        public Client(IAbstractFactory factory)
        {
            _probuctA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public void InteractWithEachOther()
        {
            _probuctA.Interact(_productB);
            _productB.Interact(_probuctA);
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            Client client1 = new Client(new ConcreteFactory1());
            
            client1.InteractWithEachOther();
            
            Client client2 = new Client(new ConcreteFactory2());
            
            client2.InteractWithEachOther();
        }
    }
}