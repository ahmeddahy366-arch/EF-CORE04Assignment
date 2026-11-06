using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Model
{
    public class manager
    {

        public int id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Hirdate { get; set; }
        public Branch branch { get; set; }
    }
}
