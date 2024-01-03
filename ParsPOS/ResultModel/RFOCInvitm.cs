using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ResultModel
{
    public class RFOCInvitm
    {
        public int Slno {  get; set; }
        public int ItemId {  get; set; }
        public float? Qty { get; set; }
        public string Unit { get; set; }
        public string Packing { get; set; }
        public string ProdCode { get; set; }
        public string ProdDescr { get; set; }
        public string Barcode { get; set; }
        public float LPCost { get; set; }
        public float ActiveCost { get; set; }
        public float Price { get; set; }
    }
}
