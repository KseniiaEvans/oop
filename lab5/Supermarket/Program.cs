using System;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            BreadMediator br_mediator = new BreadMediator();
            CandiesMediator candy_mediator = new CandiesMediator();
            СerealsMediator cereal_mediator = new СerealsMediator();
            Colleague smarket;

            Colleague kyivbread = new KyivBreadColleague(br_mediator);
            Colleague flashbake = new FlashBakeColleague(br_mediator);

            Colleague roshen = new RoshenColleague(candy_mediator);
            Colleague avk = new AVKColleague(candy_mediator);
            Colleague svitoch = new SvitochColleague(candy_mediator);
        
            Colleague cerealUk = new CerealUkraineColleague(cereal_mediator); 
            Colleague teppa = new TeppaColleague(cereal_mediator); 

            br_mediator.KyivBread = kyivbread;
            br_mediator.FlashBake = flashbake;

            candy_mediator.Roshen = roshen;
            candy_mediator.AVK = avk;
            candy_mediator.Svitoch = svitoch;

            cereal_mediator.CerealUkraine = cerealUk;
            cereal_mediator.Teppa = teppa;
            Console.WriteLine("");

            smarket = new Supermarket(br_mediator);
            smarket.Notify(100);
            
            br_mediator.Send(70, kyivbread);
            br_mediator.Send(30, flashbake);
            Console.WriteLine("");
            
            smarket = new Supermarket(candy_mediator);
            smarket.Notify(50);

            candy_mediator.Send(30, roshen);
            candy_mediator.Send(10, svitoch);
            candy_mediator.Send(10, avk);
            Console.WriteLine("");

            smarket = new Supermarket(cereal_mediator);
            smarket.Notify(150);

            cereal_mediator.Send(100, cerealUk);
            cereal_mediator.Send(50, teppa);
            Console.WriteLine("");

            // Console.Read();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(int number, Colleague colleague);
    }
    abstract class Colleague
    {
        protected Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(int number)
        {
            mediator.Send(number, this);
        }
        public abstract void Notify(int number);
    }
}
