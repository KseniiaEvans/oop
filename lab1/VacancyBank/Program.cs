/*
У банку вакансій кожна позиція характеризується 
назвою, компанією, що її пропонує, категорією 
вакансії та регіоном. Забезпечити виведення на екран 
інформації про вакансії будь-якого типу групування. 
Також реалізувати виведення тільки кількості вакансій 
з різними типами групування (за компанією, за категорією, за регіоном тощо). 
*/

using System;
using System.Collections.Generic;

namespace VacancyBank
{
    class MainApp
    {
        static void Main()
        {
            // company, region, category, name

            Composite work_ua = new Composite("Work.ua");

            Composite company_a = new Composite("Avon");
            Composite company_f = new Composite("Faberlic");
            Composite region_u = new Composite("Ukraine");
            Composite region_g = new Composite("Germany");
            Composite category_i = new Composite("IT");
            Composite category_m = new Composite("Marketing");
            Vacancy name_w = new Vacancy("Web-developer");
            Vacancy name_c = new Vacancy("Consultant");
            Vacancy name_l = new Vacancy("Lawyer");
            Vacancy name_a = new Vacancy("Accountant");
            Vacancy name_d = new Vacancy("Designer");

            company_a.Add(region_u);
            company_a.Add(region_g);
            region_u.Add(category_i);
            region_u.Add(category_m);
            region_u.Add(name_d);
            region_u.Add(name_a);
            category_i.Add(name_w);
            category_i.Add(name_c);
            region_g.Add(name_l);

            company_f.Add(name_c);
            company_f.Add(name_a);
            company_f.Add(name_l);

            
            work_ua.Add(company_a);
            work_ua.Add(company_f);
            work_ua.Display(4);

            Console.WriteLine("Number of vacancies by Avon company: " + company_a.GetVacancyCount());
            Console.WriteLine("Number of vacancies by IT category: " + category_i.GetVacancyCount());
            Console.WriteLine("Number of vacancies in Germany: " + region_g.GetVacancyCount());
            Console.WriteLine("Number of vacancies in Ukraine: " + region_u.GetVacancyCount());
            Console.WriteLine("Number of vacancies by Faberlic company: " + company_f.GetVacancyCount());
            Console.WriteLine("Number of vacancies in work_ua: " + work_ua.GetVacancyCount());


            Console.ReadKey();
        }
    }

    abstract class VacancyComponent
    {
        public string name;
        public int count;
        public string state;
        public VacancyComponent(string name)
        {
            this.name = name;
        }
        public abstract void Add(VacancyComponent c);
        public abstract int GetVacancyCount();
        public abstract void Remove(VacancyComponent c);
        public abstract void Display(int depth);
    }

    class Composite : VacancyComponent
    {
        private List<VacancyComponent> _children = new List<VacancyComponent>();

        public Composite(string name) : base(name)
        {
            this.count = 0;
            this.state = "composite";
        }

        public override void Add(VacancyComponent component)
        {
            _children.Add(component);
            this.count += 1;
        }

        public override void Remove(VacancyComponent component)
        {
            _children.Remove(component);
            this.count -= 1;
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + " " + this.count.ToString());
            foreach (VacancyComponent component in _children) 
            {
                component.Display(depth + 6);
            }
        }
        public override int GetVacancyCount()
        {
            int num = 0; 
            foreach (VacancyComponent component in _children) 
            {
                num += component.GetVacancyCount();
                
            }
            return num;
        }
    }

    class Vacancy : VacancyComponent
    {
    
        public Vacancy(string name) : base(name)
        {
            this.state = "vacancy";
            this.count = 1;
        }
        public override void Add(VacancyComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Remove(VacancyComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Display(int depth)
        {
            Console.Write(new String('-', depth));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ResetColor();
        }
        public override int GetVacancyCount() {
            return 1;
        }
    }
}
