using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class GrpItmTb
    {
        [PrimaryKey , AutoIncrement]
        public int GrpId {  get; set; }
        public string GrpItmCode { get; set; }
        public byte? LCode { get; set; }
        public string? Description { get; set; }
        public string? CategoryImage { get; set; }
        public int? ParentId { get; set; }
        public int UnqGrpId { get; set; }
        public bool? Delld {  get; set; }
        public DateTime UpdtdTm { get; set; }
    }
}
