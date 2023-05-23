using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer
{
    public class clsAccounts
    {
        public int AccountId { get; set; }

        public int ParentId { get; set; }
        public int SubAccountId { get; set; }
        public string SubAccountTitle { get; set; }
        public string AccountCode { get; set; }
        public string AccountTitle { get; set; }
        public string Nature { get; set; }
 
        public string TypeControl { get; set; }

        public string Parent { get; set; }
    }
}
