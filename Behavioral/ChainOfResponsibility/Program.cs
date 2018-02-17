using System;

namespace Behavioral.ChainOfResponsibility
{
    abstract class Handler
    {
        protected Handler _handler;

        protected Handler(Handler handler)
        {
            SetHandler(handler);
        }

        public void SetHandler(Handler handler)
        {
            _handler = handler;
        }

        public virtual void HandleRequest(Request request)
        {
            _handler?.HandleRequest(request: request);
        }
    }

    class ConcreteHandler1 : Handler
    {
        public ConcreteHandler1(Handler next) : base(next) { }

        public override void HandleRequest(Request request)
        {
            Console.Write(request.Text1);

            base.HandleRequest(request);
        }
    }

    class ConcreteHandler2 : Handler
    {
        public ConcreteHandler2(Handler handler) : base(handler) { }
    }

    class ConcreteHandler3 : Handler
    {
        public ConcreteHandler3(Handler handler) : base(handler) { }

        public override void HandleRequest(Request request)
        {
            Console.Write(request.Text2);

            base.HandleRequest(request);
        }
    }

    class Request
    {
        public string Text1 { get; } = "Hello, ";
        public string Text2 { get; } = "World!";
    }

    class Client
    {
        protected readonly Handler Handler;

        public Client()
        {
            Handler = new ConcreteHandler1(new ConcreteHandler2(new ConcreteHandler3(null)));
        }

        public void HandleRequest(Request request)
        {
            Handler.HandleRequest(request);
        }
    }

    class Program
    {
        static void Main()
        {
            Client client = new Client();

            client.HandleRequest(new Request());
        }
    }
}