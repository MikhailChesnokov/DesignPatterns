using static System.Console;

namespace Decorator
{
    internal interface IHtmlTag
    {
        void Print();
    }

    internal class Body : IHtmlTag
    {
        public void Print()
        {
            Write(
                "<body>\n" +
                "    <h3>It Works</h3>\n" +
                "</body>\n");
        }
    }

    internal abstract class Decorator : IHtmlTag
    {
        protected IHtmlTag HtmlTag { get; }

        protected Decorator(IHtmlTag htmlTag)
        {
            HtmlTag = htmlTag;
        }

        public virtual void Print()
        {
            HtmlTag.Print();
        }
    }

    internal class HeadTagDecorator : Decorator
    {
        public HeadTagDecorator(IHtmlTag htmlTag)
            : base(htmlTag) { }

        public override void Print()
        {
            Write(
                "<head>\n" +
                "    <title>SomePage</title>\n" +
                "</head>\n");

            base.Print();
        }
    }

    internal class HtmlTagDecorator : Decorator
    {
        public HtmlTagDecorator(IHtmlTag htmlTag)
            : base(htmlTag) { }

        public override void Print()
        {
            Write("<html>\n");

            base.Print();

            Write("</html>\n");
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            Decorator htmlPage = new HtmlTagDecorator(new HeadTagDecorator(new Body()));

            htmlPage.Print();
        }
    }
}