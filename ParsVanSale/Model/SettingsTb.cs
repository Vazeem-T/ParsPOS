using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
    public class SettingsTb
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int? DeviceNumber { get; set; }
		public string? Location { get; set; }
		public string? CompanyName { get; set; }
        public DateTime? SoftwareSetUp { get; set; }
        public DateTime? SoftwareValidity { get; set; }
        public string? CompanyLogo {  get; set; }
        public string? CompanyOwner { get; set; }
        public bool? IsSoftKeyboardEnable { get; set; }
        public double? CurrentVersion { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? LastInvoiceNumber { get; set; }
        public DateTime? LastInvTime {  get; set; }
        public string? LastInvoivcestatus { get; set; }
        public string? LastUser {  get; set; }
        public DateTime? UserLogoutTm { get; set; }
        public DateTime? LstImportTime {  get; set; }
        public string? LastImpUser { get; set; }
        public bool InvImgEnable {  get; set; }
        public byte[]? Logo { get; set; }
        public bool? PrintOnsubmit { get; set; }
        public bool? isTaxEnable { get; set; }
        public bool? IsApiEnable { get; set; } = false;
        public bool? IsSqlServerEnabled { get; set; } = true;
    }
}
