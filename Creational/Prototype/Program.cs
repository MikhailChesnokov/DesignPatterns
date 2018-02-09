using System;

namespace Creational.Prototype
{
    class Prototype
    {
        protected Prototype() { }

        protected Prototype(Prototype prototype) { }

        public virtual Prototype Clone()
        {
            return new Prototype();
        }
    }

    class ConcretePrototype : Prototype
    {
        public ConcretePrototype() { }

        protected ConcretePrototype(ConcretePrototype concretePrototypeDerived)
            : base(concretePrototypeDerived) { }

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
        }
    }
}