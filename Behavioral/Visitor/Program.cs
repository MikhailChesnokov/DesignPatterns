using System;

namespace Behavioral.Visitor
{
    interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA elementA);
        void VisitConcreteElementB(ConcreteElementB elementB);
    }

    class ConcreteVisitor1 : IVisitor // Summator
    {
        public void VisitConcreteElementA(ConcreteElementA elementA)
        {
            Console.WriteLine("Sum: " + (elementA.X + elementA.Y + elementA.Z));
        }

        public void VisitConcreteElementB(ConcreteElementB elementB)
        {
            Console.WriteLine("Product: " + (elementB.I + elementB.J));
        }
    }

    class ConcreteVisitor2 : IVisitor // Multiplicator
    {
        public void VisitConcreteElementA(ConcreteElementA elementA)
        {
            Console.WriteLine("Sum: " + (elementA.X * elementA.Y * elementA.Z));
        }

        public void VisitConcreteElementB(ConcreteElementB elementB)
        {
            Console.WriteLine("Product: " + (elementB.I * elementB.J));
        }
    }

    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElementA : IElement // Three elements vector
    {
        public int X { get; } = 2;
        public int Y { get; } = 3;
        public int Z { get; } = 4;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    class ConcreteElementB : IElement // Two elements vector
    {
        public int I { get; } = 5;
        public int J { get; } = 6;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    class Program
    {
        static void Main()
        {
            IVisitor[] visitors =
            {
                new ConcreteVisitor1(),
                new ConcreteVisitor2()
            };

            IElement[] elements =
            {
                new ConcreteElementA(),
                new ConcreteElementB()
            };

            foreach (IVisitor visitor in visitors)
            {
                foreach (IElement element in elements)
                {
                    element.Accept(visitor);
                }
            }
        }
    }
}