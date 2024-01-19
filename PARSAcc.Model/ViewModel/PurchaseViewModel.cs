using PARSAcc.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARSAcc.Model.ViewModel
{
    public class PurchaseViewModel
    {
        public IEnumerable<InvItm> InvItms { get; set; }
        public PurchaseDetTb PurchaseDetTb { get; set; } = new PurchaseDetTb(); // Initialize with an instance
        public IList<PurchaseDetTb> PurchaseDetTbItm { get; set; } = new List<PurchaseDetTb>(); // Initialize with an instance
    }
}
