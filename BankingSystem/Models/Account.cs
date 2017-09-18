using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public class Account
    {
        public int Id { get; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
    }
}
