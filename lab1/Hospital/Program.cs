/*
Реалізувати різноманітні методи
проведення віртуального медичного
огляду лікарями як мінімум трьох
спеціалізацій (стоматолог, хірург, ортопед і т.ін.).
Забезпечити підтримку віртуального медичного
огляду певною множиною лікарів. */

//Decorator
using System;
using System.Collections.Generic; 

class Hospital
{

    interface IDoctor
    {
        string makeConsultation();
        bool addTestToDo(string test);
        bool addTestResult(string test, string result);
        string Diagnosis();
        void showResult();

    }

    class Doctor : IDoctor
    {
        public string makeConsultation()
        {
            return "Consultations to: ";
        }
        public string Diagnosis()
        {
            return "Diagnosis: ";
        }
        public bool addTestToDo(string test)
        {
            return true;
        }
        public bool addTestResult(string test, string result)
        {
            return true;
        }
        public void showResult()
        {
            Console.WriteLine("RESULT:");
        }

    }

    class DentistDecorator : IDoctor
    {
        IDoctor doctor;
        public Dictionary<string, string> tests = new Dictionary<string, string>();
        public DentistDecorator(IDoctor d)
        {
            doctor = d;
        }
        public string makeConsultation()
        {
            string s = doctor.makeConsultation();
            s += "dentist ";
            return s;
        }

        public bool addTestToDo(string test)
        {
            tests.Add(test, "nothing");
            return true;
        }
        public bool addTestResult(string test, string result)
        {
            tests[test] = result;
            return true;
        }
        public string Diagnosis()
        {
            string s = doctor.Diagnosis();
            s += "dentistry: ill\t";
            return s;
        }
        public void showResult()
        {
            Console.WriteLine("RESULT:");
            if (tests.Count != 0)
            {
                Console.WriteLine("You passed those tests and got those results: ");
                foreach (KeyValuePair<string, string> kvp in tests)
                {
                    Console.WriteLine("Test: " + kvp.Key + ", " + "result: " + kvp.Value);
                }
                Console.WriteLine(Diagnosis());
            } else {
                Console.WriteLine("You didn't pass the tests, so I don't know your diadnosis");
            }
        }
    }

    class SurgeonDecorator : IDoctor
    {
        IDoctor doctor;
        string state = "healthy";
        public Dictionary<string, string> tests = new Dictionary<string, string>();
        public SurgeonDecorator(IDoctor d)
        {
            doctor = d;
        }
        public string makeConsultation()
        {
            string s = doctor.makeConsultation();
            s += "surgeon ";
            return s;
        }

        public bool addTestToDo(string test)
        {
            tests.Add(test, "nothing");
            return true;
        }
        public bool addTestResult(string test, string result)
        {
            tests[test] = result;
            return true;
        }
        void Analysis()
        {
            if (tests.ContainsValue("very bad"))
            {
                state = "operation";
            } else if  (tests.ContainsValue("bad")) {
                state = "ill";
            }
        }
        public string Diagnosis()
        {
            Analysis();
            string s = doctor.Diagnosis();
            s += "surgeon: " + state + "\t";
            return s;
        }
        public void showResult()
        {
            Console.WriteLine("RESULT:");
            if (tests.Count != 0)
            {
                Console.WriteLine("You passed those tests and got those results: ");
                foreach (KeyValuePair<string, string> kvp in tests)
                {
                    Console.WriteLine("Test: " + kvp.Key + ", " + "result: " + kvp.Value);
                }
                Console.WriteLine(Diagnosis());
            } else {
                Console.WriteLine("You didn't pass the tests, so I don't know your diadnosis");
            }
        }
    }

    class OrthopedistDecorator : IDoctor
    {
        IDoctor doctor;
        string state = "healthy";
        public Dictionary<string, string> tests = new Dictionary<string, string>();
        public OrthopedistDecorator(IDoctor d)
        {
            doctor = d;
        }
        public string makeConsultation()
        {
            string s = doctor.makeConsultation();
            s += "orthopedist ";
            return s;
        }

        public bool addTestToDo(string test)
        {
            tests.Add(test, "nothing");
            return true;
        }
        public bool addTestResult(string test, string result)
        {
            tests[test] = result;
            return true;
        }
        void Analysis()
        {
            if (tests.ContainsValue("very bad"))
            {
                state = "operation";
            } else if  (tests.ContainsValue("bad")) {
                state = "ill";
            }
        }
        public string Diagnosis()
        {
            Analysis();
            string s = doctor.Diagnosis();
            s += "orthopedology: " + state + "\t";
            return s;
        }
        public void showResult()
        {
            Console.WriteLine("RESULT:");
            if (tests.Count != 0)
            {
                Console.WriteLine("You passed those tests and got those results: ");
                foreach (KeyValuePair<string, string> kvp in tests)
                {
                    Console.WriteLine("Test: " + kvp.Key + ", " + "result: " + kvp.Value);
                }
                Console.WriteLine(Diagnosis());
            } else {
                Console.WriteLine("You didn't pass the tests, so I don't know your diadnosis");
            }
        }
    }

    class Client
    {
        static void Main()
        {
            IDoctor doctor = new Doctor();

            doctor = new DentistDecorator(doctor);
            doctor.makeConsultation();
            doctor.addTestToDo("blood test");
            doctor.addTestToDo("teeth shot");
            doctor.showResult();

            
            doctor = new SurgeonDecorator(doctor);
            Console.WriteLine("");
            doctor.makeConsultation();
            doctor.addTestToDo("blood test");
            doctor.addTestToDo("teeth shot");
            doctor.showResult();


            doctor = new OrthopedistDecorator(doctor);
            Console.WriteLine("");
            Console.WriteLine(doctor.makeConsultation());
            doctor.addTestToDo("Ultrasound of the joints");
            doctor.addTestToDo("massage");
            doctor.addTestResult("massage", "good");
            doctor.addTestResult("Ultrasound of the joints", "bad");
            doctor.showResult();

            Console.ReadKey();
        }
    }
}