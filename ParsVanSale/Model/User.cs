using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class User
    {
        [Unique]
        public string UserId { get; set; }
        public int Id { get; set; }
        public bool MasterYn { get; set; }
        public string Password { get; set; }
        public string? LstOpnBr {  get; set; }
        public string? DefLoc { get; set; }
        public float OPnCash { get; set; }
        public string? StripData {  get; set; }
        public short Category {  get; set; }
        public bool Suppress {  get; set; }
        public string? Photo {  get; set; }

    }
}
