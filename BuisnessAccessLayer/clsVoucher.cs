using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer
{
    public class clsVoucher
    {
     
        public int  VoucherNo { get; set; }
        public string VoucherDescription{ get; set; }
        public DateTime VDate { get; set; }
        public int VoucherTypeId { get; set; }
        public string VNature{ get; set; }

        public bool Post { get; set; }

    }
    public class clsSubVoucher 
    {


        public int SubAccountId { get; set; }
        public int VoucherNo{ get; set; }
        public string CACode { get; set; }
        public string ACName { get; set; }
        public string ACType { get; set; }

        public string Amount { get; set; }

        public string Balance { get; set; }
        public string ChequeNo { get; set; }

        public int SubVoucherNo { get; set; }
    }
}
