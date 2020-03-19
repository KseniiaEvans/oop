using System;
using System.Collections.Generic;

namespace NewYear
{
    class MainApp
    {
        public static void Main()
        {
            // Create and run the African animal world
            
            GiftsFactory santa = new SantaClausFactory();
            GiftsFactory snow_maiden = new SnowMaidenFactory();

            GiftsWorld world;
            
            world = new GiftsWorld(santa);
            world.MadeNewYearRresent();

            world = new GiftsWorld(snow_maiden);
            world.MadeNewYearRresent();

            world = new GiftsWorld(santa);
            world.MadeNewYearRresent();

            world = new GiftsWorld(snow_maiden);
            world.MadeNewYearRresent();

            world = new GiftsWorld(santa);
            world.MadeNewYearRresent();

            world = new GiftsWorld(snow_maiden);
            world.MadeNewYearRresent();

            RandomSingleton.PrintCount();
            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }

    public static class RandomSingleton //Singleton
    {
        private static Random _rnd = new Random();
        public static int _count = 0;
        private static object _sync = new object();
        public static int Next() {
            lock (_sync) {
                _count += 1;
                return _rnd.Next();
            }
        }
        public static int Next(int max) {
            lock (_sync) {
                _count += 1;
                return _rnd.Next(max);
            }
        }
        public static int Next(int min, int max) {
            lock (_sync) {
                _count += 1;
                return _rnd.Next(min, max);
            }
        }
        public static void PrintCount() {
            Console.WriteLine("\t\tAll made gifts: " + _count.ToString());
        }
    }
    
    abstract class GiftsFactory // The 'AbstractFactory' abstract class
    {
        public abstract Toys CreateToys();
        public abstract Candies CreateCandies();
    }
    
    class SantaClausFactory : GiftsFactory  // The 'ConcreteFactory1' class
    {
        public override Toys CreateToys()
        {
            if (RandomSingleton.Next(0, 10) < 5) return new Car();
            return new Pistol();
        }
        public override Candies CreateCandies()
        {
            return new BoysCandies();
        }
    }
    
    class SnowMaidenFactory : GiftsFactory  // The 'ConcreteFactory2' class
    {
        public override Toys CreateToys()
        {
            if (RandomSingleton.Next(0, 10) < 5) return new Doll();
            return new TeddyBeer();
        }
        public override Candies CreateCandies()
        {
            return new GirlsCandies();
        }
    }
    
    abstract class Toys // The 'AbstractProductA' abstract class
    {
        public abstract void Display();
    }
    
    abstract class Candies // The 'AbstractProductB' abstract class
    {
        public abstract void Display();
    }

    class Pistol : Toys
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("boy: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Pistol, ");
            Console.ResetColor();
        }
    }
    class Car : Toys
    {
        // private string[] _unicodes = new string[]{"🎮", "🧚‍♂️"};//, "\x1F693", "\x1F695", "\x1F69A", "\x1F680"
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("boy: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Car, ");
            Console.ResetColor();
        }
    }
    class Doll : Toys
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("girl: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Doll, ");
            Console.ResetColor();
        }
    }
    class TeddyBeer : Toys
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("girl: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Teddy Beer, ");
            Console.ResetColor();
        }
    }
    
    class BoysCandies : Candies // The 'ProductA2' class
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("candies candies candies candies");
            Console.ResetColor();
        }
    }
    
    class GirlsCandies : Candies // The 'ProductB2' class
    {
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("candies candies candies candies");
            Console.ResetColor();
        }
    }

    
    class GiftsWorld // The 'Client' class
    {
        private Candies _candies;
        private Toys _toys;
        // Constructor
        public GiftsWorld(GiftsFactory factory)
        {
            _toys = factory.CreateToys();
            _candies = factory.CreateCandies();
        }
        public void MadeNewYearRresent()
        {
            // Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("NewYear present for ");
            _toys.Display();
            _candies.Display();
            Console.WriteLine("--------------------------");
        }
    }
}
