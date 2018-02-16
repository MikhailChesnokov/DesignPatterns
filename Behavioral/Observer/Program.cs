using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Behavioral.Observer
{
    interface IObserver
    {
        void Update(Subject subject);
    }

    class ConcreteObserver : IObserver // Time printer
    {
        public void Update(Subject subject)
        {
            if (subject is ConcreteSubject concreteSubject)
            {
                Console.WriteLine($"Current state: {concreteSubject.GetState():hh:mm:ss}");
            }
        }
    }

    abstract class Subject
    {
        protected readonly List<IObserver> Observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            Observers.ForEach(observer => observer.Update(this));
        }
    }

    class ConcreteSubject : Subject // Clock
    {
        protected DateTime State;

        public ConcreteSubject()
        {
            State = DateTime.Now;

            Task.Run(() => // Update state every second
            {
                while (true)
                {
                    if (GetState().Second != DateTime.Now.Second)
                    {
                        SetState(DateTime.Now);
                    }

                    Thread.Sleep(200);
                }
            });
        }

        public DateTime GetState()
        {
            return State;
        }

        public void SetState(DateTime state)
        {
            State = state;

            Notify();
        }
    }

    class Program
    {
        static void Main()
        {
            Subject subject = new ConcreteSubject();

            IObserver observer = new ConcreteObserver();

            subject.Attach(observer);

            Thread.Sleep(10_000);
        }
    }
}