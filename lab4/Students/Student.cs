namespace Students 
{
    class Student
    {
        public string fullname;
        public int educationDebt = 0;
        public int financialDebt = 0;
        public Student(string fullname, int eduDebt, int finDebt)
        {
            this.fullname = fullname;
            this.educationDebt = eduDebt;
            this.financialDebt = finDebt;
        }
        public string GetStudentFullname()
        {
            return this.fullname;
        }
        public int GetStudentEduDebt()
        {
            return this.educationDebt;
        }
        public int GetStudentFinDebt()
        {
            return this.financialDebt;
        }
    }
}