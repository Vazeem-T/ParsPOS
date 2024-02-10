using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class SuppPrdTb
    {
        public int SupplierNo { get; set; }
        public int ItemId { get; set; }
        [MaxLength(30)]
        public string? IC { get; set; }
        public int BaseId { get; set; }
    }
}
