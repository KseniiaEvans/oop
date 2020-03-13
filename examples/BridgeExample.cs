/*
Пасажири метрополітену можуть 
сплачувати за проїзд або жетонами, 
або картками, доступна сума на яких 
поповнюється через спеціальні пристрої. 
За допомогою шаблону проектування 
створити структуру класів, яка б дозволяла
описати процес оплати за проїзд пасажирами обох типів. 
*/

namespace BridgeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractPassenger> passengers = new List<AbstractPassenger> 
            {
                new AbstractPassenger(new CardPassenger()), new AbstractPassenger(new CardPassenger()), new AbstractPassenger(new TokenPassenger()) 
            };

            foreach (AbstractPassenger ap in passengers)
                if (ap.PayForTransit()) 
                    Console.WriteLine("Passenger has paid"); 
                else Console.WriteLine("Passenger hasn't paid"); Console.ReadKey();
        }
    }

    interface IPassenger
    {
        bool PayForTransit();
    }
    class AbstractPassenger
    {
        IPassenger pass; 
        public AbstractPassenger(IPassenger p) 
        { 
            this.pass = p; 
        }

        public bool PayForTransit() 
        { 
            return this.pass.PayForTransit(); 
        }
    }

    class TokenPassenger : IPassenger 
    { 
        List<float> tokens = new List<float> { 2, 2, 2 }; 
        public bool PayForTransit() 
        { 
            if (tokens.Count > 0) 
            { 
                tokens.Remove(0); return true; 
            } 
        return false; 
        } 
    }

    class CardPassenger : IPassenger 
    { 
        float cardsum = 100; 
        public bool PayForTransit() 
        { 
            if (cardsum >= 2) 
            { 
                cardsum -= 2; 
                return true; 
            } 
            return false; 
        } 
    }
}



/*Результат: Passenger hasn't paid Passenger hasn't paid Passenger has paid */
