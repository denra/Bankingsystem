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
            Console.WriteLine("Velkommen til banken");
            Console.WriteLine("--------------------");
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
                default:
                    MainMenu();
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

            foreach (Customer myCustomer in Bank.GetCustomers)
            {
                nextCustomer++;
            }

            Customer customer = new Customer(nextCustomer, firstName, lastName, phone, email, decimal.Parse(account));
            Bank.GetCustomers.Add(customer);
            Console.WriteLine("Du er nu oprettet som kunde. Tryk på enter for at vende tilbage til menuen.");
            Console.ReadLine();
            MainMenu();
        }

        public static void FindCustomer()
        {
            Console.Clear();
            Console.WriteLine("----------- Find kunde -----------");
            Console.Write("Indtast kundens email: ");
            string email = Console.ReadLine();
            if (Bank.GetCustomers.Count > 0)
            {
                Customer myFoundCustomer = Bank.FindCustomer(email);
                if (myFoundCustomer != null)
                {
                    Console.WriteLine("ID: " + myFoundCustomer.Id + " Navn: " + myFoundCustomer.FullName + " Telefonnr.: " + myFoundCustomer.PhoneNumber + " Email: " + myFoundCustomer.Email + " Balance på konto: " + myFoundCustomer.Account);
                    Console.WriteLine("Tryk enter til at komme tilbage til hovedmenuen.");
                    Console.ReadLine();
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Der findes ingen kunder med denne e-mail. Prøv igen.");
                    Console.ReadLine();
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("Der er endnu ikke oprettet kunder i systemet. Start med at oprette dig som kunde.");
                Console.ReadLine();
                MainMenu();
            }
        }

        public static void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("----------- Fjern kunde -----------");
            Console.Write("indtast kundens email: ");
            string email = Console.ReadLine();
            if (Bank.GetCustomers.Count > 0)
            {
                int i = Bank.GetCustomers.Count;
                Customer myFoundCustomer = Bank.FindCustomer(email);
                if (myFoundCustomer != null)
                {
                    Bank.GetCustomers.Remove(myFoundCustomer);
                    if (i == Bank.GetCustomers.Count + 1)
                    {
                        Console.WriteLine("Kunden er nu fjernet. Tryk enter for at vende tilbage til hovedmenuen.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Der findes ingen kunder med denne e-mail. Prøv igen.");
                    Console.ReadLine();
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("Der er endnu ikke oprettet kunder i systemet. Start med at oprette dig som kunde.");
                Console.ReadLine();
                MainMenu();
            }
            MainMenu();
        }

        public static void EditCustomer()
        {
            Console.Clear();
            Console.WriteLine("----------- Rediger kunde -----------");
            Console.Write("Indtast din e-mail: ");
            string email = Console.ReadLine();

            if (Bank.GetCustomers.Count > 0)
            {
                foreach (Customer myCustomer in Bank.GetCustomers)
                {
                    if (email == myCustomer.Email)
                    {
                        Console.Clear();
                        Console.WriteLine("---------- - Rediger kunde---------- - ");
                        Console.Write("Rediger dit fornavn (nuværende : " + myCustomer.FirstName + " : ");
                        myCustomer.FirstName = Console.ReadLine();
                        Console.Write("Rediger dit efternavn (nuværende : " + myCustomer.LastName + " : ");
                        myCustomer.LastName = Console.ReadLine();
                        Console.Write("Rediger dit telefonnr. (nuværende : " + myCustomer.PhoneNumber + " : ");
                        myCustomer.PhoneNumber = Console.ReadLine();
                        Console.Write("Rediger din e-mail (nuværende : " + myCustomer.Email + " : ");
                        myCustomer.Email = Console.ReadLine();
                        Console.WriteLine("Du har nu redigeret dine informationer. Tryk på enter for at vende tilbage til menuen.");
                        Console.ReadLine();
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Der findes ingen kunder med denne e-mail. Prøv igen.");
                        Console.ReadLine();
                        MainMenu();
                    }
                }
            }
            else
            {
                Console.WriteLine("Der er endnu ikke oprettet kunder i systemet. Start med at oprette dig som kunde.");
                Console.ReadLine();
                MainMenu();
            }
        }

        public static void TransferMoney()
        {
            Console.Clear();
            Console.WriteLine("----------- Overfør penge -----------");
            Console.Write("Indtast din e-mail: ");
            string email = Console.ReadLine();

            if (Bank.GetCustomers.Count > 1)
            {
                foreach (Customer myCustomer in Bank.GetCustomers)
                {
                    if (Bank.FindCustomer(email) != null)
                    {
                        Console.Clear();
                        Console.WriteLine("----------- Overfør penge -----------");
                        Console.Write("Skriv e-mail adressen til den kunde, du vil overføre penge til: ");
                        string customerEmail = Console.ReadLine();

                        if (Bank.FindCustomer(customerEmail) == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Der findes ingen kunder med denne e-mail. Prøv igen.");
                            Console.WriteLine("Tryk på enter for at vende tilbage til menuen.");
                            Console.ReadLine();
                            MainMenu();
                        }
                        else
                        {
                            Customer otherCustomer = Bank.FindCustomer(customerEmail);

                            Console.Write("Hvor mange penge vil du overføre? ");
                            decimal moneyToAccount = decimal.Parse(Console.ReadLine());
                            if (myCustomer.Account >= moneyToAccount)
                            {
                                decimal allMyMoney = myCustomer.Account - moneyToAccount;
                                decimal allMoney = otherCustomer.Account + moneyToAccount;

                                otherCustomer.Account = allMoney;
                                myCustomer.Account = allMyMoney;

                                Console.WriteLine("");
                                Console.WriteLine("På kontoen tilknyttet " + myCustomer.Email + " er der nu " + allMyMoney + "kr.");
                                Console.WriteLine("På kontoen tilknyttet " + otherCustomer.Email + " er der nu " + allMoney + "kr.");
                                Console.WriteLine("");
                                Console.WriteLine("Tryk på enter for at vende tilbage til menuen.");
                                Console.ReadLine();
                                MainMenu();
                            }
                            else
                            {
                                Console.WriteLine("Der er ikke nok penge på kontoen.");
                                Console.WriteLine("Tryk på enter for at vende tilbage til menuen.");
                                Console.ReadLine();
                                MainMenu();
                            }
                        }
                    }
                    break;
                }
                if (Bank.FindCustomer(email) == null)
                {
                    Console.WriteLine("Der findes ingen kunder med denne e-mail. Prøv igen.");
                    Console.ReadLine();
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("Der er endnu ikke oprettet kunder i systemet. Start med at oprette dig som kunde.");
                Console.ReadLine();
                MainMenu();
            }
        }
    }
}
