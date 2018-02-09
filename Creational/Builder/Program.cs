using System;

namespace Creational.Builder
{
    class Product
    {
        public string Text { get; set; } = string.Empty;
    }

    abstract class Builder
    {
        public virtual void BuildPartA() { }
        public virtual void BuildPartB() { }
        public virtual void BuildPartC() { }
        public virtual void BuildPartX() { }

        public abstract Product GetResult();
    }

    class ConcreteBuilder : Builder
    {
        protected readonly Product Product;

        public ConcreteBuilder()
        {
            Product = new Product();
        }

        public override void BuildPartA()
        {
            Product.Text += "Hello";
        }

        public override void BuildPartB()
        {
            Product.Text += ", ";
        }

        public override void BuildPartC()
        {
            Product.Text += "World!";
        }

        // BuildPartX() doesn't need to be overriden here

        public override Product GetResult()
        {
            return Product;
        }
    }

    class Director
    {
        private readonly Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
            _builder.BuildPartX();
        }
    }

    class Program
    {
        static void Main()
        {
            Builder concreteBuilder = new ConcreteBuilder();

            Director director = new Director(concreteBuilder);

            director.Construct();

            Product product = concreteBuilder.GetResult();

            Console.WriteLine(product.Text); // Hello, World!
        }
    }
}