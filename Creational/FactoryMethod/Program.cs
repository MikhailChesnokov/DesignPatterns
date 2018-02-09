using System;

namespace Creational.FactoryMethod
{
    interface IProduct { }

    class ConcreteProductA : IProduct { }

    class ConcreteProductB : IProduct { }

    interface ICreator
    {
        IProduct FactoryMethod();
    }

    class ConcreteCreatorA : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    class Program
    {
        static void Main()
        {
            ICreator[] creators =
            {
                new ConcreteCreatorA(),
                new ConcreteCreatorB()
            };

            foreach (ICreator creator in creators)
            {
                IProduct product = creator.FactoryMethod();

                Console.WriteLine("The product type is " + product.GetType().Name);
            }
        }
    }
}