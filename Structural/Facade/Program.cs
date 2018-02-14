using System;

namespace Structural.Facade
{
    internal class SubsystemA
    {
        public void OperationA1() { }

        public void OperationA2() { }
    }

    internal class SubsystemB
    {
        public void OperationB1() { }
    }

    public interface ISubsystemC
    {
        void OperationC1();

        void OperationC2();

        void OperationC3();
    }

    internal class SubsystemC : ISubsystemC
    {
        public void OperationC1() { }

        public void OperationC2() { }

        public void OperationC3() { }
    }

    class Facade
    {
        private readonly SubsystemA _subsystemA = new SubsystemA();
        private readonly SubsystemB _subsystemB = new SubsystemB();
        private readonly ISubsystemC _subsystemC = new SubsystemC();

        public void OperationA()
        {
            _subsystemA.OperationA1();
            _subsystemA.OperationA2();

            _subsystemB.OperationB1();

            _subsystemC.OperationC3();
        }

        public void OperationB()
        {
            _subsystemC.OperationC2();
            _subsystemC.OperationC3();
        }
    }

    class Program
    {
        static void Main()
        {
            Facade facade = new Facade();

            facade.OperationA();

            facade.OperationB();
        }
    }
}