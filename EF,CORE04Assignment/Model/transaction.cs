using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Model
{
    public class transaction
    {
        public int transactionNumber { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal amount { get; set; }
        public string transactionType { get; set; }
        public string notes { get; set; }
        public int accountId { get; set; }

        public account account { get; set; }

    }
}
