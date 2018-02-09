using System;

namespace Creational.AbstractFactory
{
    interface IAbstractFactory
    {
        IAbsractProbuctA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    interface IAbsractProbuctA
    {
        void Interact(IAbstractProductB productB);
    }

    interface IAbstractProductB
    {
        void Interact(IAbsractProbuctA probuctA);
    }

    class ConcreteProbuctA1 : IAbsractProbuctA
    {
        public void Interact(IAbstractProductB productB)
        {
            Console.WriteLine("The instance of " +
                              this.GetType().Name + " is interacting with the instance of " + productB.GetType().Name);
        }
    }

    class ConcreteProductA2 : IAbsractProbuctA
    {
        public void Interact(IAbstractProductB productB)
        {
            Console.WriteLine("The instance of " +
                              this.GetType().Name + " is interacting with the instance of " + productB.GetType().Name);
        }
    }

    class ConcreteProductB1 : IAbstractProductB
    {
        public void Interact(IAbsractProbuctA probuctA)
        {
            Console.WriteLine("The instance of " +
                              this.GetType().Name + " is interacting with the instance of " + probuctA.GetType().Name);
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public void Interact(IAbsractProbuctA probuctA)
        {
            Console.WriteLine("The instance of " +
                              this.GetType().Name + " is interacting with the instance of " + probuctA.GetType().Name);
        }
    }

    class ConcreteFactory1 : IAbstractFactory
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

    class ConcreteFactory2 : IAbstractFactory
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

    class Client
    {
        private readonly IAbsractProbuctA _probuctA;
        private readonly IAbstractProductB _productB;

        public Client(IAbstractFactory factory)
        {
            _probuctA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public void DoInteract()
        {
            _probuctA.Interact(_productB);
            _productB.Interact(_probuctA);
        }
    }

    class Program
    {
        static void Main()
        {
            Client client1 = new Client(new ConcreteFactory1());

            client1.DoInteract();


            Client client2 = new Client(new ConcreteFactory2());

            client2.DoInteract();
        }
    }
}