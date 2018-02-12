using System;
using System.Collections.Generic;

namespace Behavioral.Iterator
{
    interface IIterator<out TItem> // Like IEnumerator<>
    {
        void First();
        void Next();
        bool IsDone();
        TItem CurrentItem();
    }

    interface IAggregate<out TItem> // Like IEnumerable<>
    {
        IIterator<TItem> CreateIterator();
    }

    interface IListAggregate<TItem> : IAggregate<TItem> // Like IList<>
    {
        int Count { get; }
        void Append<T>(params T[] item) where T : TItem;
        void Remove<T>(params T[] item) where T : TItem;
        TItem this[int i] { get; set; }
    }

    class ConcreteAggregate<TItem> : IListAggregate<TItem>
    {
        private readonly IList<TItem> _list = new List<TItem>();

        public int Count => _list.Count;

        public IIterator<TItem> CreateIterator()
        {
            return new ConcreteIteratorA<TItem>(this); // default ConcreteAggregate iterator
        }

        public void Append<T>(params T[] items) where T : TItem
        {
            foreach (T item in items)
            {
                _list.Add(item);
            }
        }

        public void Remove<T>(params T[] items) where T : TItem
        {
            foreach (T item in items)
            {
                _list.Remove(item);
            }
        }

        public TItem this[int i]
        {
            get => _list[i];
            set => _list[i] = value;
        }
    }

    class ConcreteIteratorA<TItem> : IIterator<TItem>
    {
        private readonly IListAggregate<TItem> _aggregate;
        private int _currennt = 0;

        public ConcreteIteratorA(IListAggregate<TItem> aggregate)
        {
            _aggregate = aggregate;
        }

        public void First()
        {
            _currennt = 0;
        }

        public void Next()
        {
            _currennt++;
        }

        public bool IsDone()
        {
            return _currennt >= _aggregate.Count;
        }

        public TItem CurrentItem()
        {
            if (IsDone())
                throw new IndexOutOfRangeException();

            return _aggregate[_currennt];
        }
    }

    class ConcreteIteratorB<TItem> : IIterator<TItem>
    {
        private readonly IListAggregate<TItem> _aggregate;
        private int _currennt = 0;

        public ConcreteIteratorB(IListAggregate<TItem> aggregate)
        {
            _aggregate = aggregate;
        }

        public void First()
        {
            _currennt = _aggregate.Count - 1;
        }

        public void Next()
        {
            _currennt--;
        }

        public bool IsDone()
        {
            return _currennt < 0;
        }

        public TItem CurrentItem()
        {
            if (IsDone())
                throw new IndexOutOfRangeException();

            return _aggregate[_currennt];
        }
    }

    class Program
    {
        static void Main()
        {
            IListAggregate<int> aggregate = new ConcreteAggregate<int>();

            aggregate.Append(1, 2, 3, 4, 5, 6, 7, 8, 9);

            IIterator<int>[] iterators =
            {
                new ConcreteIteratorA<int>(aggregate),
                new ConcreteIteratorB<int>(aggregate),
                aggregate.CreateIterator()
            };

            foreach (IIterator<int> iterator in iterators)
            {
                for (iterator.First(); !iterator.IsDone(); iterator.Next())
                {
                    Console.Write(iterator.CurrentItem());
                }

                Console.WriteLine();
            }
        }
    }
}