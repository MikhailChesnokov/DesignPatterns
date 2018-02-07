using static System.Console;

namespace AbstractFactory
{
    internal interface IUserInterfaceAbstractFactory
    {
        IAbsractWindow CreateWindow();
        IAbstractButton CreateButton();
    }

    internal interface IAbsractWindow
    {   
        void Interact(IAbstractButton button);
    }

    internal interface IAbstractButton
    {
        void Interact(IAbsractWindow window);
    }

    internal class LinuxWindow : IAbsractWindow
    {
        public void Interact(IAbstractButton button)
        {
            WriteLine("The instance of " + typeof(LinuxWindow).Name + " is interacting with the instance of " + button.GetType().Name);
        }
    }

    internal class AppleWindow : IAbsractWindow
    {
        public void Interact(IAbstractButton button)
        {
            WriteLine("The instance of " + typeof(AppleWindow).Name + " is interacting with the instance of " + button.GetType().Name);
        }
    }

    internal class LinuxButton : IAbstractButton
    {
        public void Interact(IAbsractWindow window)
        {
            WriteLine("The instance of " + typeof(LinuxButton).Name + " is interacting with the instance of " + window.GetType().Name);
        }
    }

    internal class AppleButton : IAbstractButton
    {
        public void Interact(IAbsractWindow window)
        {
            WriteLine("The instance of " + typeof(AppleButton).Name + " is interacting with the instance of " + window.GetType().Name);
        }
    }

    internal class LinuxFactory : IUserInterfaceAbstractFactory
    {
        public IAbsractWindow CreateWindow()
        {
            return new LinuxWindow();
        }

        public IAbstractButton CreateButton()
        {
            return new LinuxButton();
        }
    }

    internal class AppleFactory : IUserInterfaceAbstractFactory
    {
        public IAbsractWindow CreateWindow()
        {
            return new AppleWindow();
        }

        public IAbstractButton CreateButton()
        {
            return new AppleButton();
        }
    }

    internal class Client
    {
        private readonly IAbsractWindow _window;
        private readonly IAbstractButton _button;
        
        public Client(IUserInterfaceAbstractFactory factory)
        {
            _window = factory.CreateWindow();
            _button = factory.CreateButton();
        }

        public void OnInteract()
        {
            _window.Interact(_button);
            _button.Interact(_window);
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            Client client1 = new Client(new AppleFactory());
            
            client1.OnInteract();
            
            Client client2 = new Client(new LinuxFactory());
            
            client2.OnInteract();
        }
    }
}