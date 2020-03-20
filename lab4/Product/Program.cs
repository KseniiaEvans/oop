using System;

namespace Product
{
    class Client
    {
        static void Main(string[] args)
        {
            ContextFood milk = new ContextFood();
            milk.SetState(ContextFood.FoodStateSetting.Useful);
            milk.Сonsume();
            
            ContextFood meat = new ContextFood();
            meat.SetState(ContextFood.FoodStateSetting.Harmful);
            meat.Сonsume();

            ContextFood fish = new ContextFood();
            fish.SetState(ContextFood.FoodStateSetting.Useful);
            fish.Сonsume();

            ContextFood cheese = new ContextFood();
            cheese.SetState(ContextFood.FoodStateSetting.Harmful);
            cheese.Сonsume();
        }
    }
    abstract class State
    {
        protected string strStatename;
        abstract public void Сonsume();
    }
    class UsefulState : State
    {
        public UsefulState()
        {
            strStatename = "Useful";
        }
        override public void Сonsume()
        {
            Console.WriteLine("Bon Appetit!");
        }
    }
    class HarmfulState : State
    {
        public HarmfulState()
        {
            strStatename = "Harmful";
        }
        override public void Сonsume()
        {
            Console.WriteLine("ERROR - product is expired!");
        }
    }

    class ContextFood
    {
        public enum FoodStateSetting {
            Harmful,
            Useful
        };
        UsefulState usefulState = new UsefulState();
        HarmfulState harmfulState = new HarmfulState();
        private State CurrentState;
        public ContextFood()
        {
            // Initialize to closed
            CurrentState = harmfulState;
        }
        
        public void SetState(FoodStateSetting newState)
        {
            if (newState == FoodStateSetting.Harmful)
            {
                CurrentState = harmfulState;
            }
            else
            {
                CurrentState = usefulState;
            }
        }
        public void Сonsume()
        {
            CurrentState.Сonsume();
            Console.WriteLine("------------------");
        }
    }
    

}
