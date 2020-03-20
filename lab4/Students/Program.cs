using System;
using System.Collections.Generic;

namespace Students
{
    // public enum Debt{
    //     Educational,
    //     Financial
    // }; 

    // public enum Parameter{
    //     Fullname,
    //     EducationalDebt,
    //     FinancialDebt
    // };
    // 
    // // abstract class IStudentStrategy
    // // {
    // //     // double CalculateTax(double amount);
    // //     List<Student> _students = new List<Student>();
    // //     public enum Debt{
    // //         Educational,
    // //         Financial
    // //     }; 

    // //     public enum Parameter{
    // //         Fullname,
    // //         EducationalDebt,
    // //         FinancialDebt
    // //     }; 
    // //     public abstract void MakeStudentsList(List<Student> students, Debt debt);
    // //     public abstract void SortStudetnsList(List<Student> students, Parameter param);
    // //     public abstract void PrintStudentsList();
    // // }


    // class SortedList : IStudetns
    // {
    //     List<Student> _st = new List<Student>();
    //     public List<Student> MakeStudentsList(List<Student> students, Parameter param)
    //     {
    //         switch (param)
    //         {
    //             case Parameter.Fullname: {
    //                 SortByFullname(students);
    //                 break;
    //             }
    //             case Parameter.EducationalDebt: {
    //                 SortByEducationalDebt(students);
    //                 break;
    //             }
    //             case Parameter.FinancialDebt: {
    //                 SortByEducationalDebt(students);
    //                 break;
    //             }
    //             default: {
    //                 Console.WriteLine("ERROR");
    //                 break;
    //             }
    //         }
    //         return _st;
    //     }
    //     void makeEducationDebtList(List<Student> students)
    //     {
    //         foreach(Student st in students)
    //         {
    //             if (st.GetStudentEduDebt() != 0)
    //             {
    //                 this._st.Add(st);
    //             }
    //         }
    //     }
    //     void makeFinancialDebtList(List<Student> students)
    //     {
    //         foreach(Student st in students)
    //         {
    //             if (st.GetStudentFinDebt() != 0)
    //             {
    //                 this._st.Add(st);
    //             }
    //         }
    //     }
    // }
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
            StudentsList students_c = new StudentsList(curstudents);

            students_a.SetMakeListStrategy(new MakeListByEducationDebt());
            students_a.SetSortStrategy(new SortByFullname());
            students_a.SetPrintStrategy(new PrintWholeList());

            Console.WriteLine("List at the beginning: ");
            students_a.Print();

            Console.WriteLine("Maked by Education Debt list: ");
            students_a.Make();
            students_a.Print();

            Console.WriteLine("Sorted by fullname list and printed only by fullname: ");
            students_a.SetPrintStrategy(new PrintListByName());
            students_a.Sort();
            students_a.Print();

            Console.WriteLine("Sorted by education debt list: ");
            students_a.SetSortStrategy(new SortByEducationDebt());
            students_a.SetPrintStrategy(new PrintListByNameAndEduDebt());
            students_a.Sort();
            students_a.Print();

            Console.WriteLine("Sorted by finance debt list: ");
            students_a.SetSortStrategy(new SortByFinanceDebt());
            students_a.SetPrintStrategy(new PrintListByNameAndFinDebt());
            students_a.Sort();
            students_a.Print();
            // students_b.Make();

            
            // studentRecords.SetSortStrategy(new SortByFullname());
            // studentRecords.Sort();

            // studentRecords.SetSortStrategy(new SortByEducationDebt());
            // studentRecords.Sort();

            // studentRecords.SetSortStrategy(new SortByFinanceDebt());
            // studentRecords.Sort();

            // Wait for user
            Console.ReadKey();
        }
    }

    class StudentsList /// The 'Context' clas
    {
        private List<Student> _list = new List<Student>();
        private SortStrategy _sortstrategy;
        private MakeListStrategy _makeliststrategy;
        private PrintStrategy _printstrategy;

        public StudentsList(List<Student> students)
        {
            this._list = students;
        }
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void SetMakeListStrategy(MakeListStrategy makestrategy)
        {
            this._makeliststrategy = makestrategy;
        }

        public void SetPrintStrategy(PrintStrategy printstrategy)
        {
            this._printstrategy = printstrategy;
        }
        public void Sort()
        {
            _sortstrategy.Sort(_list);
        }
        public void Make()
        {
            this._list = _makeliststrategy.MakeList(_list);   
        }
        public void Print()
        {
            _printstrategy.PrintList(_list);
        }
    }

}
