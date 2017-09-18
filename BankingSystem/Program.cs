using BankingSystem.Models;
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
            switch (command)
            {
                case "1":
                    CreateCustomer();
                    break;
                case "2":
                    FindCustomer(); //Dennis
                    break;
                case "3":
                    DeleteCustomer(); //Dennis
                    break;
                case "4":
                    EditCustomer(); //Camilla
                    break;
                case "5":
                    TransferMoney(); // Camilla
                    break;

            }
        }

        public static void CreateCustomer()
        {
            Console.Clear();
            Console.WriteLine("----------- Tilføj ny kunde -----------");
            Console.Write("Indtast dit fornavn: ");
            string firstName = Console.ReadLine();
            Console.Write("Indtast dit efternavn: ");
            string lastName = Console.ReadLine();
            Console.Write("Indtast dit telefonnr.: ");
            string phone = Console.ReadLine();
            Console.Write("Indtast din e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Hvor mange penge vil du indsætte på din nye konto? ");
            string account = Console.ReadLine();
            int nextCustomer = 1;
            Customer customer = new Customer(nextCustomer, firstName, lastName, phone, email, decimal.Parse(account));
            nextCustomer++;
            Bank.AddCustomers.Add(customer);
            MainMenu();
        }

        public static void DeleteCustomer()
        {

            MainMenu();
        }
    }
}
