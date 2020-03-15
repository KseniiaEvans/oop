using System;
using System.Collections;
using System.Collections.Generic; 

namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            AccessControlTariff Prime_ControlTariff = new AccessControlTariff();
            Client m1 = new Client() { name = "John", PUK_code = 12345678, current_tariff = "Lifehack"};
            Client m2 = new Client() { name = "Steve_Jons#4562", PUK_code = 11994523, current_tariff = "4Unlimited"};
            Client m3 = new Client() { name = "Emma_Stown#6541", PUK_code = 12345678, current_tariff = "Lifehack"};
            
            Prime_ControlTariff.Change_Tariff(m1);
            Console.WriteLine("");

            Prime_ControlTariff.Change_Tariff(m2);
            Console.WriteLine("");
            
            Prime_ControlTariff.Change_Tariff(m3);
            Console.WriteLine("");

            // Console.ReadKey();
        }
    }

    class Client
    {
        public string name;
        public int PUK_code;
        public string current_tariff;
    }
    
    abstract class Abst_Tariff // interface
    {
        public abstract void Change_Tariff(Client m);
    }
    
    class Tariff : Abst_Tariff // RealSubject
    {
        Database bd = new Database();
        public override void Change_Tariff(Client m)
        {
            Console.WriteLine("Hi, {0}! You can change your <<{1}>> tariff to :", m.name, m.current_tariff);
            bd.GetTariffsInfo();
        }
    }

    public class Database 
    {
        private Hashtable clients = new Hashtable();
        private List<string> tariffs = new List<string>();
        public Database()
        {
            Create_ClientsBD();
            Create_TariffsBD();
        }
        void Create_ClientsBD()
        {
            this.clients.Add("Kris_Evans#8542", 13212312);
            this.clients.Add("Steve_Jons#4562", 11994523);
            this.clients.Add("Emma_Stown#6541", 15263524);
            this.clients.Add("Jennifer_Aniston#6378", 15974826);
            this.clients.Add("Johnny_Depp#4523", 96300548);
            this.clients.Add("Angelina_Jolie#7420", 41203269);
            this.clients.Add("Brooke_Shields#3097", 78030614);
        }

        void Create_TariffsBD()
        {
            tariffs.Add("4Unlimited");
            tariffs.Add("Lifehack");
            tariffs.Add("Gadget");
            tariffs.Add("Platinum");
            tariffs.Add("Smart family");
            tariffs.Add("Comfort");
            tariffs.Add("Bomba");
            tariffs.Add("Handmade");
        }

        public int GetClientInfo(string name)
        {
            try {
                return (int)this.clients[name];
            }
            catch {
                return -1;
            }
        }

        public void GetTariffsInfo()
        {
            foreach(string tr in tariffs)
            {
                Console.Write("Tafriff <<");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(tr);
                Console.ResetColor();

                Console.WriteLine(">>");
            }
        }
         
     
    }

    class AccessControlTariff : Abst_Tariff // Proxy
    {
        Tariff tariff = new Tariff();
        Database bd = new Database();

        public override void Change_Tariff(Client cl)
        {
            
            int client_pass = bd.GetClientInfo(cl.name);
            if (client_pass == cl.PUK_code)
            {
                tariff.Change_Tariff(cl);
            }
            else if (client_pass == -1)
            {
                Console.WriteLine("Sorry, {0}, you are not our client!", cl.name);
            }
            else
                Console.WriteLine("Not today, {0} :( Your PUK-code is uncorrect", cl.name);
        }
    }
}

