using System;
namespace Supermarket
{
    class BreadMediator : Mediator // постачальник хлібу
    {
        public Colleague FlashBake { get; set; }
        public Colleague KyivBread { get; set; }
        public override void Send(int number, Colleague colleague)
        {
            if (FlashBake == colleague)
            {
                FlashBake.Notify(number);
            }
            else if (KyivBread == colleague)
            {
                KyivBread.Notify(number);
            }
        }
    }

    class FlashBakeColleague : Colleague
    {
        
        public FlashBakeColleague(Mediator mediator)
            : base(mediator)
        {
        }

        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Flash Bake");
            Console.ResetColor();
            Console.Write(" is ready to bake ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number.ToString() + " lofts of bread.");
            Console.ResetColor();
        }
    }
     class  KyivBreadColleague : Colleague
    {
        public KyivBreadColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(int number)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Kyiv Bread");
            Console.ResetColor();
            Console.Write(" is ready to bake ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number.ToString() + " lofts of bread.");
            Console.ResetColor();
        }
    }
}