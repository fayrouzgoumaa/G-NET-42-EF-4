using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_42_EF_4.Models
{
    internal class AccountCustomer
    {
        public int AccountNumber { get; set; }

        public Account Account { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string OwnershipType { get; set; }

        public DateTime OwnershipStartDate { get; set; }

        public string AccountStatus { get; set; }
    }
}
