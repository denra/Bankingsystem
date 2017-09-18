using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string fullName;
        private string phoneNumber;
        private string address;
        private string email;
        private int zip;
        //kunne måske fjerne
        private string country;
        private string city;
        public Customer(int newId)
        {
            id = newId;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string FullName
        {
            get
            {
                return firstName + " " + lastName;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
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
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public int Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
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
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
    }
}
