using System;
using System.Collections.Generic;
namespace Students
{
    abstract class MakeListStrategy /// The 'Strategy' abstract class
    {
        public abstract List<Student> MakeList(List<Student> list);
    }
    class MakeListByFinanceDebt : MakeListStrategy
    {
        public override List<Student> MakeList(List<Student> list)
        {
            List<Student> _st = new List<Student>();
            foreach(Student st in list)
            {
                if (st.GetStudentFinDebt() != 0)
                {
                    _st.Add(st);
                }
            }
            return _st;
        }
    }

    class MakeListByEducationDebt : MakeListStrategy
    {
        public override List<Student> MakeList(List<Student> list)
        {
            List<Student> _st = new List<Student>();
            foreach(Student st in list)
            {
                if (st.GetStudentEduDebt() != 0)
                {
                    _st.Add(st);
                }
            }
            return _st;
        }
    }
}