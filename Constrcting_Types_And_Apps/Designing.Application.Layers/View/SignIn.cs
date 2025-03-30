using Designing.Application.Layers.Model;

namespace Designing.Application.Layers.View
{
    public sealed class SignIn
    {
        private Greeting greeting;

        public SignIn()
        {
            greeting = new Greeting();
        }

        public void Greet()
        {
            Console.Write("Is this your first visit? (true/false): ");
            string newResponse = Console.ReadLine();
            bool.TryParse(newResponse, out bool isNew);
            string greetResponse = greeting.GetGreeting(isNew);
            Console.WriteLine($"\n*\n* {greetResponse} \n*\n");
        }
    }
}
