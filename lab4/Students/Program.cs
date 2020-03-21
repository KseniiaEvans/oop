using System;
using System.Collections.Generic;

namespace Students
{
    class MainApp
    {
        static void Main()
        {
            List<Student> curstudents = new List<Student>() {
                new Student("Samual", 1, 140),
                new Student("Jimmy", 4, 0),
                new Student("Sandra", 5, 100),
                new Student("Angelina", 0, 0),
                new Student("Vivek", 7, 50),
                new Student("Anna", 2, 0),
                new Student("Sofia", 0, 150)
            } ;
            StudentsList students_a = new StudentsList(curstudents);
            StudentsList students_b = new StudentsList(curstudents);

            students_a.GetResult(new MakeListByEducationDebt(), new SortByFullname(), new PrintWholeList());
            students_b.GetResult(new MakeListByFinanceDebt(), new SortByFinanceDebt(), new PrintListByNameAndFinDebt());

            Console.ReadKey();
        }
    }

    class StudentsList /// The 'Context' clas
    {
        private List<Student> _list = new List<Student>();
        private SortStrategy _sortstrategy;
        private MakeListStrategy _makeliststrategy;
        private PrintStrategy _printstrategy;

        public void GetResult(MakeListStrategy makestrategy, SortStrategy sortstrategy, PrintStrategy printstrategy)
        {
            this._makeliststrategy = makestrategy;
            this._sortstrategy = sortstrategy;
            this._printstrategy = printstrategy;

            this.Make();
            this.Sort();
            this.Print();

            Console.WriteLine("Successfully done!\n");

        }
        public StudentsList(List<Student> students)
        {
            this._list = students;
        }
        private void Sort()
        {
            _sortstrategy.Sort(_list);
        }
        private void Make()
        {
            this._list = _makeliststrategy.MakeList(_list);   
        }
        private void Print()
        {
            _printstrategy.PrintList(_list);
        }
    }
}
