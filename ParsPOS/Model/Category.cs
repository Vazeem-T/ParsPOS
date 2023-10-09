using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class Category
    {
        [PrimaryKey,AutoIncrement]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int GrpItmCode { get; set; }
        public int ParentId { get; set; }
        public  string CategoryImage { get ; set; }
        public bool Delld { get; set; }
        public DateTime UpdatedTm { get; set; }
    }
}
