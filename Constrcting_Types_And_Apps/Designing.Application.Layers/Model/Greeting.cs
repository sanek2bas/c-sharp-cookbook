using Designing.Application.Layers.Data;

namespace Designing.Application.Layers.Model
{
    public sealed class Greeting
    {
        private GreetingRepository greetRep;

        public Greeting()
        {
            greetRep = new GreetingRepository();
        }

        public string GetGreeting(bool isNew) =>
            isNew ? greetRep.GetNewGreeting() : greetRep.GetVisitGreeting();
    }
}
