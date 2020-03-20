using System;
using System.Collections.Generic;
namespace Students
{
    abstract class PrintStrategy /// The 'Strategy' abstract class
    {
        public abstract void PrintList(List<Student> list);
    }
    class PrintWholeList : PrintStrategy
    {
        public override void PrintList(List<Student> list)
        {
            foreach(Student st in list)
            {
                Console.Write("Name: " + st.GetStudentFullname());
                Console.Write(", education debt: " + st.GetStudentEduDebt());
                Console.WriteLine(", financial debt: " + st.GetStudentFinDebt());
            }
            Console.WriteLine("");
        }
    }
    class PrintListByName : PrintStrategy
    {
        public override void PrintList(List<Student> list)
        {
            foreach(Student st in list)
            {
                Console.WriteLine("Name: " + st.GetStudentFullname());
            }
            Console.WriteLine("");
        }
    }
    class PrintListByNameAndFinDebt : PrintStrategy
    {
        public override void PrintList(List<Student> list)
        {
            foreach(Student st in list)
            {
                Console.Write("Name: " + st.GetStudentFullname());
                Console.WriteLine(", financial debt: " + st.GetStudentFinDebt());
            }
            Console.WriteLine("");
        }
    }
    class PrintListByNameAndEduDebt : PrintStrategy
    {
        public override void PrintList(List<Student> list)
        {
            foreach(Student st in list)
            {
                Console.Write("Name: " + st.GetStudentFullname());
                Console.WriteLine(", education debt: " + st.GetStudentEduDebt());
            }
            Console.WriteLine("");
        }
    }
}