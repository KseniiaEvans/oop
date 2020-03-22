using System;
namespace Supermarket
{
    class CandiesMediator : Mediator // постачальник товарів рошен, світоч, авк
    {
        public Colleague Roshen { get; set; }
        public Colleague AVK { get; set; }
        public Colleague Svitoch { get; set; }
        public override void Send(int number, Colleague colleague)
        {
            if (Roshen == colleague)
            {
                Roshen.Notify(number);
            }
            else if (AVK == colleague)
            {
                AVK.Notify(number);
            }
            else if (Svitoch == colleague)
            {
                Svitoch.Notify(number);
            }
        }
    }

    class RoshenColleague : Colleague
    {
        public RoshenColleague(Mediator mediator)
            : base(mediator)
        { }
        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Roshen");
            Console.ResetColor();
            Console.Write(" is ready to sell ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(number.ToString() + " packs of candies.");
            Console.ResetColor();
        }
    }
    class AVKColleague : Colleague
    {
        public AVKColleague(Mediator mediator)
            : base(mediator)
        { }
        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("AVK");
            Console.ResetColor();
            Console.Write(" is ready to sell ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(number.ToString() + " packs of candies.");
            Console.ResetColor();
        }
    }
    class SvitochColleague : Colleague
    {
        public SvitochColleague(Mediator mediator)
            : base(mediator)
        { }
        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Svitoch");
            Console.ResetColor();
            Console.Write(" is ready to sell ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(number.ToString() + " packs of candies.");
            Console.ResetColor();
        }
    }

}