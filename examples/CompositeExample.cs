/*
Мікрорайон міста складається з вулиць, 
вулиці - з будинків, будинки – з квартир. 
Кожна квартира споживає електроенергію. 
Cтворити структуру класів, яка б дозволяла 
отримувати інформацію щодо споживання 
електроенергії по квартирі, будинку, вулиці 
та мікрорайону в цілому. */

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            Composite district = new Composite("KPI-1");                         //streets             
            Composite street1 = new Composite("Metallistov street");             
            district.Add(street1);             
            Composite street2 = new Composite("Kovalsky lane");             
            district.Add(street2);             //buildings                         
            Composite build1 = new Composite("build#10");             
            Composite build2 = new Composite("build#12");             
            Composite build3 = new Composite("build#5"); 

            street1.Add(build1); 
            street1.Add(build2); 
            street2.Add(build3); 
            Flat fl1 = new Flat("#1"); 
            Flat fl2 = new Flat("#1"); 
            Flat fl3 = new Flat("#2"); 
            Flat fl4 = new Flat("#1");
            build1.Add(fl1); 
            build2.Add(fl2); 
            build2.Add(fl3); 
            build3.Add(fl4); 
            district.GetElectroInfo();
            district.Display(2);
            Console.ReadKey();
        }     
    } 


    abstract class ResidentalComponent
    {
        protected string name; protected int electro;
        public ResidentalComponent(string name)
        {             
            this.name = name;         
        } 
        public abstract void Add(ResidentalComponent c); 
        public abstract void Remove(ResidentalComponent c); 
        public abstract int GetElectroInfo(); 
        public abstract void Display(int depth);
    }

    class Composite : ResidentalComponent     
    {
        private List<ResidentalComponent> _children = new List<ResidentalComponent>(); 

        public Composite(string name) : base(name)          
        {             
            this.electro = 0;         
        } 

        public override void Add(ResidentalComponent component) 
        {
            _children.Add(component); 
        }

        public override void Remove(ResidentalComponent component) 
        { 
            _children.Remove(component); 
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + " " + this.electro.ToString());    
            foreach (ResidentalComponent component in _children)
                component.Display(depth + 2);          
        }
        public override int GetElectroInfo() 
        { 
            this.electro = 0; 
            foreach (ResidentalComponent component in _children) 
                this.electro += component.GetElectroInfo(); 
            return this.electro; 
        }
    }


    class Flat : ResidentalComponent
    {
        public Flat(string name) : base(name) 
        { 
            Random rnd = new Random(); 
            this.electro = rnd.Next(150); 
        }
        public override void Add(ResidentalComponent c) 
        { 
            Console.WriteLine("Impossible operation"); 
        }
        public override void Remove(ResidentalComponent c) 
        { 
            Console.WriteLine("Impossible operation"); 
        }
        public override void Display(int depth) 
        { 
            Console.WriteLine(new String('-', depth) + name + " " + electro.ToString()); 
        }
        public override int GetElectroInfo() 
        { 
            return this.electro; 
        }
    }
}