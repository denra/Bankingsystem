using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            Console.WriteLine("Velkommen til banken");
            Console.WriteLine("1. Tilføj ny kunde.");
            Console.WriteLine("2. Find Kunde og konto.");
            Console.WriteLine("3. Fjern kunde.");
            Console.WriteLine("4. Redigere kunde.");
            Console.WriteLine("5. Overfør penge");
            Console.WriteLine("--------------------");
            string command = Console.ReadLine();
            switch(command)
            {
                case "1":
                    CreateCustomer();
                    break;
                case "2":
                    FindCustomer();
                    break;
                case "3":
                    DeleteCustomer();
                    break;
                case "4":
                    EditCustomer();
                    break;
                case "5":
                    TransferMoney();
                    break;

            }
        }
    }
}
