using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Model
{
    public class AccountCustomer
    {
        public string ownerShipType { get; set; }
        public string AccountStuats { get; set; }
        public DateTime ownerShipStartDate { get; set; }
        public int accountsId { get; set; }
        public account accounts { get; set; }
        public int customersId { get; set; }

        public customer customers { get; set; }

    }
}
