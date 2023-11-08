using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class PreFixTb
    {
        public int Id { get; set; }
        public int? VrTypeNo { get; set; }
        [JsonProperty("Voucher Name")]
        [StringLength(50)]
        public string? VoucherName { get; set; }
        [StringLength(15)]
        public string? PreFix { get; set; }
        public int? VrNo { get; set; }
        public bool Enable {  get; set; }
        public int? ANo { get; set; }
        public int? ANo2 { get; set; }
        [StringLength(10)]
        public string? BrId { get; set; }
        public short? Ctgry { get; set; }
        public short IconNo { get; set; }
        public bool Delld {  get; set; }
        public string? Image { get; set; }
    }
}
