using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class NetworkIP
    {
        [PrimaryKey ,AutoIncrement]
        public int Id { get; set; }
        public string ConnectionName { get; set; }
        public string IPAddress { get; set; }
        public int PortNumber { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastDbUsed { get; set; }
        public bool IsConnected { get; set; }
    }
}
