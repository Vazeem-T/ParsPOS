using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ResultModel
{
    public class PaymentOption
    {
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public double  PaymentAmount { get; set; }
        public double TenderedAmount { get; set; }
    }
}
