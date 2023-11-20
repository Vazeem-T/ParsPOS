using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class SettingsTb
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int? CounterNumber { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? SofwareSetUp { get; set; }
        public DateTime? SoftwareValidity { get; set; }
        public string? CompanyLogo {  get; set; }
        public string? CompanyOwner { get; set; }
        public bool? IsSoftKeyboardEnable { get; set; }
        public bool? IsNumberPadEnabled { get; set; }
        public double? CurrentVersion { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? BDateTime { get; set; }
        public int? LastInvoiceNumber { get; set; }
        public DateTime? LastInvTime {  get; set; }
        public string? LastInvoivcestatus { get; set; }
        public string? LastUser {  get; set; }
        public DateTime? UserLogoutTm { get; set; }
        public DateTime? LstImportTime {  get; set; }
        public string? LastImpUser { get; set; }
    }
}
