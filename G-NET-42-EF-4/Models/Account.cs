using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace G_NET_42_EF_4.Models
{
    internal class Account
    {
        public int AccountNumber { get; set; }

        public decimal CurrentBalance { get; set; }

        public string AccountType { get; set; }

        public DateTime OpeningDate { get; set; }

        public int BranchCode { get; set; }

        public Branch Branch { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new List<Transaction>();

        public ICollection<AccountCustomer> AccountCustomers { get; set; }
            = new List<AccountCustomer>();
    }
}
