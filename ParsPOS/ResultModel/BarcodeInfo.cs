using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ResultModel
{
    public class BarcodeInfo
    {
        public string BarCode {  get; set; }
        
        public double Price { get; set; }
        public int Certificate { get; set; }
    }
}
