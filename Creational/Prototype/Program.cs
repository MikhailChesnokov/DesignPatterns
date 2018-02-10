using System;

namespace Creational.Prototype
{
    class Prototype
    {
        protected Prototype() { }

        protected Prototype(Prototype prototypeDerived) { }

        public virtual Prototype Clone()
        {
            return new Prototype();
        }
    }

    class ConcretePrototype : Prototype
    {
        public int[] ReferenceTypeField = new int[1];

        public ConcretePrototype() { }

        protected ConcretePrototype(ConcretePrototype concretePrototype)
            : base(concretePrototype)
        {
            ReferenceTypeField = new int[concretePrototype.ReferenceTypeField.Length];
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype(this);
        }
    }

    class ConcretePrototypeDerived : ConcretePrototype
    {
        public ConcretePrototypeDerived() { }

        protected ConcretePrototypeDerived(ConcretePrototypeDerived concretePrototypeDerived)
            : base(concretePrototypeDerived) { }

        public override Prototype Clone()
        {
            return new ConcretePrototypeDerived(this);
        }
    }

    class Program
    {
        static void Main()
        {
            Prototype prototype = new ConcretePrototypeDerived();

            Prototype prototypeCopy = prototype.Clone();

            Console.WriteLine("The instance of " + prototype.GetType().Name +
                              " is not equal to instance of " + prototypeCopy.GetType().Name +
                              ": " + (prototype != prototypeCopy));

            Console.WriteLine("The reference fields of " + prototype.GetType().Name +
                              " is not equal to reference fields of " + prototypeCopy.GetType().Name + ": " +
                              (((ConcretePrototypeDerived) prototype).ReferenceTypeField !=
                               ((ConcretePrototypeDerived) prototypeCopy).ReferenceTypeField));
        }
    }
}