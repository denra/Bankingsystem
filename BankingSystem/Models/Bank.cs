using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public class Bank
    {
        private string name;
        private string address;
        private int zipcode;
        private string city;

        private static List<Customer> customers = new List<Customer>();

        public Bank(string newName)
        {
            name = newName;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public int Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                zipcode = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public static List<Customer> GetCustomers
        {
            get
            {
                return customers;
            }
        }

        public static Customer FindCustomer(string mail)
        {
            if (Bank.GetCustomers.Count > 0)
            {
                foreach (Customer myCustomer in customers)
                {
                    if (myCustomer.Email == mail)
                    {
                        return myCustomer;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
