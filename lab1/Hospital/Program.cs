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

    interface IDoctor //IComponent 
    {
        string makeConsultation();
        bool addTestToDo(string test);
        bool addTestResult(string test, string result);
        string Diagnosis();
        void showResult();

    }

    class Doctor : IDoctor // class Component : IComponent
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

    class DentistDecorator : IDoctor //class DecoratorA : IComponent
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RESULT:");
            Console.ResetColor();
        
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

    class SurgeonDecorator : IDoctor //class DecoratorB : IComponent
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RESULT:");
            Console.ResetColor();
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

    class OrthopedistDecorator : IDoctor //class DecoratorС : IComponent
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("RESULT:");
            Console.ResetColor();
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
            List<IDoctor> doctors = new List<IDoctor>();
            doctors.Add(new DentistDecorator(doctor));
            doctors.Add(new SurgeonDecorator(doctor));
            doctors.Add(new OrthopedistDecorator(doctor));
            foreach(IDoctor dc in doctors) {
                Console.WriteLine("");
                Console.WriteLine(dc.makeConsultation());

                dc.addTestToDo("blood test");
                dc.addTestToDo("Analysis of urine");
                dc.addTestResult("blood test", "good");
                dc.addTestResult("Analysis of urine", "good");
                dc.showResult();
            }

            
            // doctor = new SurgeonDecorator(doctor);
            // Console.WriteLine("");
            // doctor.makeConsultation();
            // doctor.addTestToDo("blood test");
            // doctor.addTestToDo("teeth shot");
            // doctor.showResult();


            // doctor = new OrthopedistDecorator(doctor);
            // Console.WriteLine("");
            // Console.WriteLine(doctor.makeConsultation());
            // doctor.addTestToDo("Ultrasound of the joints");
            // doctor.addTestToDo("massage");
            // doctor.addTestResult("massage", "good");
            // doctor.addTestResult("Ultrasound of the joints", "bad");
            // doctor.showResult();

            Console.ReadKey();
        }
    }
}