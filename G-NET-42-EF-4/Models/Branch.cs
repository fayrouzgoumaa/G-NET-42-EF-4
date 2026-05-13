using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_42_EF_4.Models
{
    internal class Branch
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

       
        public Manager Manager { get; set; }

        public ICollection<Account> Accounts { get; set; }
            = new List<Account>();
    }
}
