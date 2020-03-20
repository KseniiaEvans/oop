using System;
using System.Collections.Generic;
namespace Students
{
    abstract class SortStrategy /// The 'Strategy' abstract class
    {
        public abstract void Sort(List<Student> list);
    }

    class SortByFullname : SortStrategy, IComparer<Student>  /// A 'ConcreteStrategy' class
    { 
        public int Compare(Student x, Student y) 
        { 
            
            if (x == null || y == null) { 
                return 0; 
            } 
            return x.fullname.CompareTo(y.fullname);             
        } 
        public override void Sort(List<Student> list)
        {
            list.Sort(Compare);
        }
    }

    class SortByEducationDebt : SortStrategy, IComparer<Student> /// A 'ConcreteStrategy' class
    {
        public int Compare(Student x, Student y) 
        {  
            if (x.educationDebt > y.educationDebt) {
                return 1;
            } else if (x.educationDebt < y.educationDebt)
            {
                return -1;
            }
            else return 0;
        } 
        public override void Sort(List<Student> list)
        {
            list.Sort(Compare);
        }
    }

    class SortByFinanceDebt : SortStrategy, IComparer<Student> /// A 'ConcreteStrategy' class
    {
        public int Compare(Student x, Student y) 
        {   
            if (x.financialDebt > y.financialDebt) {
                return 1;
            } else if (x.financialDebt < y.financialDebt)
            {
                return -1;
            }
            else return 0;          
        } 
        public override void Sort(List<Student> list)
        {
            list.Sort(Compare);
        }
    }
}