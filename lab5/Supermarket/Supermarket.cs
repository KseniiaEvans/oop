using System;
namespace Supermarket
{
    class Supermarket : Colleague
    {
        public Supermarket(Mediator mediator)
            : base(mediator)
        {}

        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Order by supermarket: " + number.ToString() + " pieces");
            Console.ResetColor();
        }
    }
}