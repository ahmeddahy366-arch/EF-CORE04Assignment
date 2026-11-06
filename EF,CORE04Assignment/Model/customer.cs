using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Model
{
    public class customer
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string PhoneNumber { get; set; }
        public  DateTime dateOfbirth { get; set; }
        public string customerType { get; set; }
        public string nationalld { get; set; }
        public ICollection<AccountCustomer> accountCustomer { get; set; }

    }
}
