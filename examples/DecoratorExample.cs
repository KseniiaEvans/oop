/*
У зброярському магазині продаються гвинтівки. 
Кожна з них має свої характеристики: назва моделі, 
кількість набоїв тощо. На гвинтівку можна встановити 
додаткові пристрої: глушник, снайперський приціл і т.д.
Cтворити структуру класів, яка б дозволяла описати
функціональні характеристики вдосконаленої гвинтівки. 
*/


namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Створюємо екземпляр класу "Гвинтівка" та два "Декоратори"      
            Weapon R1 = new Rifle("Colt 45m", 20, 80, 100);
            Decorator S1 = new SilencerDecorator();
            Decorator S2 = new SightDecorator();

            //Пов’язуємо декоратори та робимо виклики             
            S1.SetGadgetOn(R1);
            S2.SetGadgetOn(S1);
            S2.Show_Info();
            S2.Make_Shot();

            //Очікування на відгук користувача  
            Console.ReadKey();
        }
    }


    //Абстрактний клас "Зброя"     
    abstract class Weapon
    {
        protected string Model;
        protected int Ammunition;
        protected byte Accuracy;
        protected byte Noisiness;
        public abstract void Show_Info();
        public abstract void Make_Shot();
    }

    //Гвинтівка     
    class Rifle : Weapon
    {
        public Rifle(string M, byte A, byte N, int Am)
        {
            this.Model = M;
            this.Accuracy = A;
            this.Noisiness = N;
            this.Ammunition = Am;
        }
        public override void Show_Info()
        {
            Console.WriteLine("This is rifle.\nModel - {0}\nAccuracy - {1}\nNoisness - {2}\nAmmunition - {3}",
                this.Model,
                this.Accuracy,
                this.Noisiness,
                this.Ammunition);
        }
        public override void Make_Shot()
        {
            if (Ammunition == 0)
            {
                Console.WriteLine("Out of ammunition");
                return;
            }
            Ammunition--;
            Console.WriteLine("Shot is made. Ammunition left: {0}", Ammunition);
        }
    }
    //Декоратор     
    abstract class Decorator : Weapon
    {
        protected Weapon Wp;
        public void SetGadgetOn(Weapon baseWeapon)
        {
            this.Wp = baseWeapon;
        }
        public override void Show_Info()
        {
            if (Wp != null) Wp.Show_Info();
        }
        public override void Make_Shot()
        {
            if (Wp != null) Wp.Make_Shot();
        }
    }

    //Конкретні декоратори:     //Глушник    
    class SilencerDecorator : Decorator
    {
        public override void Make_Shot()
        {
            Console.Write("Shot was silenced.");
            base.Make_Shot();
        }
        public override void Show_Info()
        {
            base.Show_Info();
            Console.WriteLine("Additional Gadget: Silencer");
        }
    }

    //Приціл   
    class SightDecorator : Decorator
    {
        public override void Make_Shot()
        {
            Console.Write("Shot was corrected.");
            base.Make_Shot();
        }
        public override void Show_Info()
        {
            base.Show_Info();
            Console.WriteLine("Additional Gadget: Sight\n");
        }
    }
}