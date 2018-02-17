using System;

namespace Behavioral.TemplateMethod
{
    abstract class AbstractClass // A simple sentence
    {
        public void TemplateMethod()
        {
            PrimitiveOperation1(); // Print subject
            PrimitiveOperation2(); // Print predicate
            PrimitiveOperation3(); // Print complement
            PrimitiveOperation4(); // Print end of sentence punctuation mark
        }

        protected virtual void PrimitiveOperation1()
        {
            Console.Write("Somebody ");
        }

        protected virtual void PrimitiveOperation2()
        {
            Console.Write("does ");
        }

        protected virtual void PrimitiveOperation3()
        {
            Console.Write("somethig");
        }

        protected virtual void PrimitiveOperation4()
        {
            Console.WriteLine('.');
        }
    }

    class ConcreteClassA : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.Write("Alice ");
        }
    }

    class ConcreteClassB : AbstractClass
    {
        protected override void PrimitiveOperation2()
        {
            Console.Write("writes ");
        }

        protected override void PrimitiveOperation3()
        {
            Console.Write("a code");
        }
    }

    class ConcreteClassC : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.Write("Bob ");
        }

        protected override void PrimitiveOperation2()
        {
            Console.Write("learns ");
        }

        protected override void PrimitiveOperation3()
        {
            Console.Write("the patterns");
        }

        protected override void PrimitiveOperation4()
        {
            Console.WriteLine('!');
        }
    }

    class Program
    {
        static void Main()
        {
            AbstractClass[] abstractClasses =
            {
                new ConcreteClassA(),
                new ConcreteClassB(),
                new ConcreteClassC()
            };

            foreach (AbstractClass abstractClass in abstractClasses)
            {
                abstractClass.TemplateMethod();
            }
        }
    }
}