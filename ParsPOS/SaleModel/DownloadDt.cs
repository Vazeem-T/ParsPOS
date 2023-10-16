using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.SaleModel
{
    public class DownloadDt
    {
        [PrimaryKey, AutoIncrement]
        public int DownloadId { get; set; }
        public string Description { get; set; }
        public int TotalCount { get; set; }
        public int? Progress { get; set; }
        public string DownloadDescription { get; set; }
        public DateTime DownloadTime { get; set; } = DateTime.Now;
        public bool IsRunning { get; set; }
        public bool? IsSuccess { get; set; }

        public DownloadDt Clone() => MemberwiseClone() as DownloadDt;
    }
}
