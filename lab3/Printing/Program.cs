using System;

namespace Printing
{
    class Program
    {
        static void Main()
        {
            Abst_Permit product;
            Creator pass = new ConcreteCreatorPass();
            Creator order = new ConcreteCreatorOrder();
            product = pass.FactoryMethod("Kseniya Lakhman", "Temporary", "01.05.2020");
            product.Print();

            product = pass.FactoryMethod("Danylo Shapovalov", "One-time", "20.02.2021");
            product.Print();
            
            product = order.FactoryMethod("Nastya Glushko", "for introduction", "08.04.2020");
            product.Print();

            Console.ReadKey();
        }
    }

    abstract class Abst_Permit
    {
        protected string name;
        protected string type;
        protected string validity;
        public abstract void Print();
    }
    class Pass : Abst_Permit //ProductA
    {
        string _message;
        public Pass(string name, string type, string validity) {
            this.name = name;
            this.type = type;
            this.validity = validity;
        }
        public override void Print()
        {
            Console.WriteLine("\tPass:\t \t \tfor:\t \tup to:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t" + this.type + "\t" + this.name + "\t\t" + this.validity + "\t" + "\n");
            Console.ResetColor(); 
        }
    }
    class Order: Abst_Permit //ProductB
    {
        string _message;
        public Order(string name, string type, string validity) {
            this.name = name;
            this.type = type;
            this.validity = validity;
        }
        public override void Print()
        {
            Console.WriteLine("\tOrder:\t \t \tfor:\t \tup to:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t" + this.type + "\t" + this.name + "\t\t" + this.validity + "\n");
            Console.ResetColor(); 
        }
    }
    class DefaultProduct : Abst_Permit
    {
        public override void Print()
        {
            Console.WriteLine("Not available permit");
        }
    }

    abstract class Creator
    {
        public abstract Abst_Permit FactoryMethod(string name, string type, string validity);
    }
    class ConcreteCreatorPass : Creator
    {
        public override Abst_Permit FactoryMethod(string name, string type, string validity) 
        { 
            return new Pass(name, type, validity); 
        }
    }

    class ConcreteCreatorOrder : Creator
    {
        public override Abst_Permit FactoryMethod(string name, string type, string validity) 
        { 
            return new Order(name, type, validity); 
        }
    }

}
