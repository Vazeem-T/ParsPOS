using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class NetworkIP
    {
        [PrimaryKey ,AutoIncrement]
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string Protocol {  get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastDbUsed { get; set; }
        public bool IsConnected { get; set; }


        [Ignore]
        public int SlNo { get; set; }
    }
}
