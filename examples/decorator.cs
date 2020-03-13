using System;
class DecoratorPattern
{

    interface IDoctor
    {
        string Operation();
    }

    class Doctor : IDoctor
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    class DentistDecorator : IDoctor
    {
        IComponent component;

        public DecoratorA(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "and listening to Classic FM ";
            return s;
        }
    }

    class SurgeonDecorator : IDoctor
    {
        IComponent component;
        public string addedState = "past the Coffee Shop ";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "to school ";
            return s;
        }

        public string AddedBehavior()
        {
            return "and I bought a cappuccino ";
        }
    }

    class Client
    {

        static void Display(string s, IDoctor c)
        {
            Console.WriteLine(s + c.Operation());
        }

        static void Main()
        {
            Console.WriteLine("Decorator Pattern\n");

            IDoctor doctor = new Doctor();
            Display("1. Basic doctor: ", doctor);
            Display("2. A-decorated : ", new DentistDecorator(doctor));
            Display("3. B-decorated : ", new SurgeonDecorator(doctor));
            Display("4. B-A-decorated : ", new SurgeonDecorator( new DentistDecorator(doctor)));
            // Explicit DecoratorB
            SurgeonDecorator surgeon = new DecoratorB(new Doctor());
            
            Display("5. A-B-decorated : ", new DecoratorA(b));
            // Invoking its added state and added behavior
            Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
            Console.ReadKey();
        }
    }
}

/* Output
   Decorator Pattern

   1. Basic component: I am walking
   2. A-decorated : I am walking and listening to Classic FM
   3. B-decorated : I am walking to school
   4. B-A-decorated : I am walking and listening to Classic FM to school
   5. A-B-decorated : I am walking to school and listening to Classic FM
            past the Coffee Shop and I bought a cappuccino
   */
