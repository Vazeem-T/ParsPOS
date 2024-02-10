using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class UnitsTb
    {
       
        [PrimaryKey]
        [MaxLength(10)]
        public string Units { get; set; }
        [MaxLength(30)]
        public string? Description { get; set; }
        public short? FraCount { get; set; }
        public bool IsDefault { get; set; }
        public bool? Delld { get; set; }
        public DateTime UpdtdTm {  get; set; }
    }
}
