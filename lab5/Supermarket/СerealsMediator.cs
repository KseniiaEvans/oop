using System;
namespace Supermarket
{
    class СerealsMediator : Mediator // постачальник товарів гречка, рис, крупи
    {
        public Colleague CerealUkraine { get; set; }
        public Colleague Teppa { get; set; }
        public override void Send(int number, Colleague colleague)
        {
            if (CerealUkraine == colleague)
            {
                CerealUkraine.Notify(number);
            }
            else if (Teppa == colleague)
            {
                Teppa.Notify(number);
            }
        }
    }

    class CerealUkraineColleague : Colleague
    {
        public CerealUkraineColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Cereal Ukraine");
            Console.ResetColor();
            Console.Write(" is ready to sell ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(number.ToString() + " packs of buckwheat.");
            Console.ResetColor();
        }
    }

    class TeppaColleague : Colleague
    {
        public TeppaColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Teppa");
            Console.ResetColor();
            Console.Write(" is ready to sell ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(number.ToString() + " packs of rice.");
            Console.ResetColor();
        }
    }
}